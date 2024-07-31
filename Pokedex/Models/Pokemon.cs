using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;

[Table("Pokemon")]
public class Pokemon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Numero { get; set; }

    [Required]
    public int RegiaoId { get; set; }
    [ForeignKey("RegiaoId")]
    public Regiao Regiao { get; set; }

    [Required]
    public int GeneroId { get; set; }
    [ForeignKey("GeneroId")]
    public Genero Genero { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public decimal Altura { get; set; }

    public decimal Peso { get; set; }

    public string Imagem { get; set; }

    public string Animacao { get; set; }

    public ICollection<PokemonTipo> Tipos { get; set; }
}
