using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Models;

namespace Compte.API.Models;

public partial class BankStbContext : DbContext
{
    public BankStbContext()
    {
    }

    public BankStbContext(DbContextOptions<BankStbContext> options)
        : base(options)
    {
    }

   
    public virtual DbSet<STBEverywhere.Models.Compte> Comptes { get; set; }

    public virtual DbSet<CompteCheque> CompteCheques { get; set; }

    public virtual DbSet<CompteCourant> CompteCourants { get; set; }

    public virtual DbSet<CompteEnDevise> CompteEnDevises { get; set; }

    public virtual DbSet<CompteEpargne> CompteEpargnes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= oumaimayahyaoui ;Initial Catalog=BankSTB;Trusted_Connection=True;Encrypt=False; TrustServerCertificate=true;Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<STBEverywhere.Models.Compte>(entity =>
        {
            entity.HasKey(e => e.CompteId).HasName("PK__Compte__DFFC42A828E2D7A5");

            entity.ToTable("Compte");

            entity.Property(e => e.CompteId).ValueGeneratedNever();
            entity.Property(e => e.NumCompte).HasMaxLength(100);
            entity.Property(e => e.Solde).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Comptes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Compte__ClientId__398D8EEE");
        });

        modelBuilder.Entity<CompteCheque>(entity =>
        {
            entity.HasKey(e => e.CompteId).HasName("PK__CompteCh__DFFC42A83603A510");

            entity.ToTable("CompteCheque");

            entity.Property(e => e.CompteId).ValueGeneratedNever();

            entity.HasOne(d => d.Compte).WithOne(p => p.CompteCheque)
                .HasForeignKey<CompteCheque>(d => d.CompteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompteChe__Compt__3C69FB99");
        });

        modelBuilder.Entity<CompteCourant>(entity =>
        {
            entity.HasKey(e => e.CompteId).HasName("PK__CompteCo__DFFC42A84D39EEC5");

            entity.ToTable("CompteCourant");

            entity.Property(e => e.CompteId).ValueGeneratedNever();

            entity.HasOne(d => d.Compte).WithOne(p => p.CompteCourant)
                .HasForeignKey<CompteCourant>(d => d.CompteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompteCou__Compt__3F466844");
        });

        modelBuilder.Entity<CompteEnDevise>(entity =>
        {
            entity.HasKey(e => e.CompteId).HasName("PK__CompteEn__DFFC42A83BE6C929");

            entity.ToTable("CompteEnDevise");

            entity.Property(e => e.CompteId).ValueGeneratedNever();

            entity.HasOne(d => d.Compte).WithOne(p => p.CompteEnDevise)
                .HasForeignKey<CompteEnDevise>(d => d.CompteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompteEnD__Compt__4222D4EF");
        });

        modelBuilder.Entity<CompteEpargne>(entity =>
        {
            entity.HasKey(e => e.CompteId).HasName("PK__CompteEp__DFFC42A8E1F1B03D");

            entity.ToTable("CompteEpargne");

            entity.Property(e => e.CompteId).ValueGeneratedNever();
            entity.Property(e => e.TauxDeRemuneration).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Compte).WithOne(p => p.CompteEpargne)
                .HasForeignKey<CompteEpargne>(d => d.CompteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompteEpa__Compt__44FF419A");
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
