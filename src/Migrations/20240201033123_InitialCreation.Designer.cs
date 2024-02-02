﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromoreApi.Data;

#nullable disable

namespace PromoreApi.Migrations
{
    [DbContext(typeof(PromoreDataContext))]
    [Migration("20240201033123_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PromoreApi.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("DATE")
                        .HasColumnName("BirthdayDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Cpf");

                    b.Property<string>("LotId")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("MothersName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("MothersName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Phone");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("PromoreApi.Entities.Lot", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Block");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT")
                        .HasColumnName("Comments");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2024, 2, 1, 3, 31, 23, 419, DateTimeKind.Utc).AddTicks(4750))
                        .HasColumnName("LastModifiedDate");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("INT")
                        .HasColumnName("Status");

                    b.Property<DateTime>("SurveyDate")
                        .HasColumnType("DATE")
                        .HasColumnName("SurveyDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("UserId");

                    b.ToTable("Lot", (string)null);
                });

            modelBuilder.Entity("PromoreApi.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("DATE")
                        .HasColumnName("EndDate");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("EstablishedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DATE")
                        .HasColumnName("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("PromoreApi.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("PromoreApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("BIT")
                        .HasColumnName("Active");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email")
                        .HasAnnotation("EmailAddress", true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Profession")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Profession");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_User_Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserRegion", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RegionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRegion");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("PromoreApi.Entities.Client", b =>
                {
                    b.HasOne("PromoreApi.Entities.Lot", "Lot")
                        .WithMany("Clients")
                        .HasForeignKey("LotId")
                        .HasConstraintName("FK_Lot_Client");

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("PromoreApi.Entities.Lot", b =>
                {
                    b.HasOne("PromoreApi.Entities.Region", "Region")
                        .WithMany("Lots")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Lot_Region");

                    b.HasOne("PromoreApi.Entities.User", "User")
                        .WithMany("Lots")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Lot_User");

                    b.Navigation("Region");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRegion", b =>
                {
                    b.HasOne("PromoreApi.Entities.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRegion_UserId");

                    b.HasOne("PromoreApi.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRegion_RegionId");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("PromoreApi.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");

                    b.HasOne("PromoreApi.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");
                });

            modelBuilder.Entity("PromoreApi.Entities.Lot", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PromoreApi.Entities.Region", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("PromoreApi.Entities.User", b =>
                {
                    b.Navigation("Lots");
                });
#pragma warning restore 612, 618
        }
    }
}
