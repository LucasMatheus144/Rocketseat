using System.ComponentModel.DataAnnotations;
using Livraria.API.Enums;

namespace Livraria.API.Entites;

public class Livro
{
    public int Id { get; set; }

    private string _titulo;

    [Required]
    [MaxLength(50, ErrorMessage = "O campo Titulo não pode ter mais de 50 caracteres.")]
    [MinLength(10, ErrorMessage = "O campo Titulo precisa ter pelo menos 10 caracteres.")]
    public string Titulo
    {
        get => _titulo;
        set => _titulo = value.ToLower();
    }
    
    [Required(ErrorMessage ="O Campo Autor é obrigadorio")]
    [MaxLength(50, ErrorMessage = "O campo Autor não pode ter mais de 50 caracteres.")]
    [MinLength(10, ErrorMessage = "O campo Autor precisa ter pelo menos 10 caracteres.")]
    public string Autor { get; set; }
    
    [Required]
    public TipoGenero Tipo { get; set; }
    
    [Required]
    public decimal preco { get; set; }
    
    public int Qntd_Estoque { get; set; }
    
}