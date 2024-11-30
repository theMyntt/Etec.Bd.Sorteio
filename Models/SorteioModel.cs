using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etec.Sorteio.Models;

[Table("sorteios")]
public class SorteioModel
{
    [Key]
    [Column("id_sorteio")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("id_participante")]
    public int ParticipantId { get; set; }

    [Column("id_amigo_secreto")]
    public int SecretFriendId { get; set; }
}
