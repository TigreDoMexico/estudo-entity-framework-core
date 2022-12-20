using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Console.Models;

public class Autor
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = "";
}