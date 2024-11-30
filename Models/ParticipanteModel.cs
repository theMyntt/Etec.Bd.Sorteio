using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etec.Sorteio.Models;

[Table("participantes")]
public class ParticipanteModel
{
    [Key]
    [Column("id_participante")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("nome")]
    public required string Name { get; set; }
}
