using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STBEverywhere.Models;

public partial class BankStbContext : DbContext
{
    public BankStbContext()
    {
    }

    public BankStbContext(DbContextOptions<BankStbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carte> Cartes { get; set; }

    public virtual DbSet<CarteElectronique> CarteElectroniques { get; set; }

    public virtual DbSet<CarteVisaPremier> CarteVisaPremiers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Compte> Comptes { get; set; }

    public virtual DbSet<CompteCheque> CompteCheques { get; set; }

    public virtual DbSet<CompteCourant> CompteCourants { get; set; }

    public virtual DbSet<CompteEnDevise> CompteEnDevises { get; set; }

    public virtual DbSet<CompteEpargne> CompteEpargnes { get; set; }

    public virtual DbSet<Transction> Transctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= oumaimayahyaoui ;Initial Catalog=BankSTB;Trusted_Connection=True;Encrypt=False; TrustServerCertificate=true;Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carte>(entity =>
        {
            entity.HasKey(e => e.CarteId).HasName("PK__Carte__C012A23C22375BE2");

            entity.ToTable("Carte");

            entity.Property(e => e.CarteId).ValueGeneratedNever();
            entity.Property(e => e.CodeSecretCarte).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NumCarte).HasMaxLength(100);

            entity.HasOne(d => d.Client).WithMany(p => p.Cartes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Carte__ClientId__4D94879B");
        });

        modelBuilder.Entity<CarteElectronique>(entity =>
        {
            entity.HasKey(e => e.CarteId).HasName("PK__CarteEle__C012A23C46DD2DCB");

            entity.ToTable("CarteElectronique");

            entity.Property(e => e.CarteId).ValueGeneratedNever();

            entity.HasOne(d => d.Carte).WithOne(p => p.CarteElectronique)
                .HasForeignKey<CarteElectronique>(d => d.CarteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarteElec__Carte__5070F446");
        });

        modelBuilder.Entity<CarteVisaPremier>(entity =>
        {
            entity.HasKey(e => e.CarteId).HasName("PK__CarteVis__C012A23CBF11B395");

            entity.ToTable("CarteVisaPremier");

            entity.Property(e => e.CarteId).ValueGeneratedNever();

            entity.HasOne(d => d.Carte).WithOne(p => p.CarteVisaPremier)
                .HasForeignKey<CarteVisaPremier>(d => d.CarteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarteVisa__Carte__534D60F1");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A2433903137");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.Prenom).HasMaxLength(100);
        });

        modelBuilder.Entity<Compte>(entity =>
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

        modelBuilder.Entity<Transction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transcti__55433A6BB2EC79A8");

            entity.ToTable("Transction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Autorisation).HasMaxLength(100);
            entity.Property(e => e.Montant).HasColumnType("decimal(18, 2)");

            entity.HasMany(d => d.Comptes).WithMany(p => p.Transactions)
                .UsingEntity<Dictionary<string, object>>(
                    "CompteTransaction",
                    r => r.HasOne<Compte>().WithMany()
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CompteTra__Compt__4AB81AF0"),
                    l => l.HasOne<Transction>().WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CompteTra__Trans__49C3F6B7"),
                    j =>
                    {
                        j.HasKey("TransactionId", "CompteId").HasName("PK__CompteTr__C8BCFE4106C36BFB");
                        j.ToTable("CompteTransaction");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
