using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etec.Sorteio.Models;

[Table("mensagens")]
public class MensagemModel
{
    [Key]
    [Column("id_mensagem")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("id_remetente")]
    public int SenderId { get; set; }

    [Column("id_destinatario")]
    public int RecipientId { get; set; }

    [Column("mensagem")]
    public required string Message { get; set; }
}
