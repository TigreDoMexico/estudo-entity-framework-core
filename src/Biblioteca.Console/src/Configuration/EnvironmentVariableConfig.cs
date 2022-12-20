using Microsoft.Extensions.Configuration;

namespace Biblioteca.Console.Configuration;

public static class EnvironmentVariableConfig
{
    public static IConfigurationRoot GetEnvironmentVariable()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");
        return configuration.Build();
    }

    public static string GetSqlServerConnectionString(this IConfigurationRoot config)
    {
        return config.GetConnectionString("SqlServer") ?? "";
    }
}