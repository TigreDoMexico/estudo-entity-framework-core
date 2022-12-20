using Microsoft.Extensions.Configuration;

namespace Biblioteca.Data.Configuration;

internal static class EnvironmentVariableConfig
{
    internal static IConfigurationRoot GetEnvironmentVariable()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");
        return configuration.Build();
    }

    internal static string GetSqlServerConnectionString(this IConfigurationRoot config)
    {
        return config.GetConnectionString("SqlServer") ?? "";
    }
}