using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models;

public class Autor
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = "";
}