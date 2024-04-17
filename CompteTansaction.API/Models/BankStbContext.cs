using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CompteTansaction.API.Models;

public partial class BankStbContext : DbContext
{
    public BankStbContext()
    {
    }

    public BankStbContext(DbContextOptions<BankStbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompteTransaction> CompteTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= oumaimayahyaoui ;Initial Catalog=BankSTB;Trusted_Connection=True;Encrypt=False; TrustServerCertificate=true;Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompteTransaction>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.CompteId }).HasName("PK__CompteTr__C8BCFE4106C36BFB");

            entity.ToTable("CompteTransaction");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
