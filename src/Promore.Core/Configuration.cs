namespace Promore.Core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();
    public static bool IsMockDataBase { get; set; } = false;
    
    
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
    
    public class SecretsConfiguration
    {
        public string JwtPrivateKey { get; set; } = string.Empty;
    }
}