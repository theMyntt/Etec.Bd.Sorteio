using System;
using Etec.Sorteio.Models;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio.Context;

public class DatabaseContext : DbContext
{
    public DbSet<MensagemModel> Mensagens { get; set; }
    public DbSet<ParticipanteModel> Participantes { get; set; }
    public DbSet<PresenteModel> Presentes { get; set; }
    public DbSet<SorteioModel> Sorteios { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Sorteio
        modelBuilder.Entity<SorteioModel>()
            .HasOne<ParticipanteModel>()
            .WithMany()
            .HasForeignKey(x => x.ParticipantId);

        modelBuilder.Entity<SorteioModel>()
            .HasOne<ParticipanteModel>()
            .WithMany()
            .HasForeignKey(x => x.SecretFriendId);

        // Presentes
        modelBuilder.Entity<PresenteModel>()
            .HasOne<SorteioModel>()
            .WithMany()
            .HasForeignKey(x => x.RaffleId);

        // Mensagens
        modelBuilder.Entity<MensagemModel>()
            .HasOne<ParticipanteModel>()
            .WithMany()
            .HasForeignKey(x => x.RecipientId);

        modelBuilder.Entity<MensagemModel>()
            .HasOne<ParticipanteModel>()
            .WithMany()
            .HasForeignKey(x => x.SenderId);

        base.OnModelCreating(modelBuilder);
    }
}
