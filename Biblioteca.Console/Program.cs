using Biblioteca.Console.Service;

using (var service = new LivroService())
{
    service.ObterAutor();
}