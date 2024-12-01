using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etec.Sorteio.Models;

[Table("presentes")]
public class PresenteModel
{
    [Key]
    [Column("id_presente")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("id_sorteio")]
    public int? RaffleId { get; set; }

    [Required]
    [Column("descricao")]
    public required string About { get; set; }
}