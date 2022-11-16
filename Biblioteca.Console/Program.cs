using Biblioteca.Console.Service;
using Biblioteca.Console.src.Configuration;

var connectionString = EnvironmentVariableConfig
    .GetEnvironmentVariable()
    .GetSqlServerConnectionString();

using (var service = new LivroService(connectionString))
{
    service.ObterAutor();
}

