using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Client.API.Models;

public partial class BankStbContext : DbContext
{
    public BankStbContext()
    {
    }

    public BankStbContext(DbContextOptions<BankStbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Client> Clients { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= oumaimayahyaoui ;Initial Catalog=BankSTB;Trusted_Connection=True;Encrypt=False; TrustServerCertificate=true;Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A2433903137");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.Prenom).HasMaxLength(100);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
