using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrugManagement.Data.Entities;

public partial class DmsdbContext : DbContext
{
    public DmsdbContext()
    {
    }

    public DmsdbContext(DbContextOptions<DmsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDrug> TblDrugs { get; set; }

    public virtual DbSet<TblSupplier> TblSuppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-44V8PND;Database=DMSDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDrug>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDrugs__3214EC079E1BA460");

            entity.ToTable("tblDrugs");

            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.ManufacturedDate)
                .HasColumnType("date")
                .HasColumnName("MAnufacturedDate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblDrugs)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__tblDrugs__Suppli__267ABA7A");
        });

        modelBuilder.Entity<TblSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__tblSuppl__4BE666B46B0CF035");

            entity.ToTable("tblSuppliers");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
