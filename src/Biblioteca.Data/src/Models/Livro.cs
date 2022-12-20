using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Data.Models;

public class Livro
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = "";

    [ForeignKey("Id")]
    public Autor Autor { get; set; } = new Autor();
}