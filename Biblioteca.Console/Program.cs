using Biblioteca.Console.Service;
using Biblioteca.Console.Configuration;

var connectionString = EnvironmentVariableConfig
    .GetEnvironmentVariable()
    .GetMariaDbConnectionString();

using (var service = new LivroService(connectionString))
{
    service.AdicionarNovoAutor();
}

