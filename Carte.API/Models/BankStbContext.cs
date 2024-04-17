using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Carte.API.Models;

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

            entity.HasOne(d => d.Client).WithMany()
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

      
       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
