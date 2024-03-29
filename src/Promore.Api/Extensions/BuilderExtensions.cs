using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Promore.Api.Services;
using Promore.Core;
using Promore.Core.Contexts.ClientContext;
using Promore.Core.Contexts.ClientContext.Contracts;
using Promore.Core.Contexts.LotContext;
using Promore.Core.Contexts.LotContext.Contracts;
using Promore.Core.Contexts.RegionContext;
using Promore.Core.Contexts.RegionContext.Contracts;
using Promore.Core.Contexts.RoleContext.Contracts;
using Promore.Core.Contexts.UserContext;
using Promore.Core.Contexts.UserContext.Contracts;
using Promore.Infra.Data;
using Promore.Infra.Repositories.Database;
using Promore.Infra.Repositories.Mock;

namespace Promore.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfigurationKeys(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString = builder.Configuration.GetConnectionString("Default");
        Configuration.Secrets.JwtPrivateKey = builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? string.Empty;
        Configuration.IsMockDataBase = builder.Configuration.GetValue<bool>("MockDataSource");
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<PromoreDataContext>(options =>
            options.UseSqlServer(
                Configuration.Database.ConnectionString,
                b => b.MigrationsAssembly("Promore.Api")
                )
            );
    }
    
    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
        
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
    
    public static void AddAuthorizationPolicies(this WebApplicationBuilder builder)
        => builder.Services.AddAuthorization(x =>
        {
            x.AddPolicy("admin", p => p.RequireRole("admin"));
            x.AddPolicy("manager", p => p.RequireRole("manager"));
        });
        
    public static void AddRepositoryServices(this WebApplicationBuilder builder)
    {
        if (Configuration.IsMockDataBase)
        {
            builder.Services.AddScoped<IUserRepository, UserRepositoryMock>();
            builder.Services.AddScoped<IRegionRepository, RegionRepositoryMock>();
            builder.Services.AddScoped<IClientRepository, ClientRepositoryMock>();
            builder.Services.AddScoped<ILotRepository, LotRepositoryMock>();
            builder.Services.AddScoped<IRoleRepository, RoleRepositoryMock>();
            builder.Services.AddSingleton<MockContext>();
        }
        else
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ILotRepository, LotRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            
            builder.Services.AddScoped<PromoreDataContext>();
        }
        
        builder.Services.AddScoped<UserHandler>();
        builder.Services.AddScoped<ClientHandler>();
        builder.Services.AddScoped<RegionHandler>();
        builder.Services.AddScoped<LotHandler>();
        builder.Services.AddScoped<TokenService>();
    }
    
    public static void AddSwaggerConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

        });
    }

    public static void JsonIgnoreCycles(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddJsonOptions(options => 
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }
    
}