using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication23.ModelsDB;

public partial class PlantsContext : DbContext
{
    public PlantsContext()
    {
    }

    public PlantsContext(DbContextOptions<PlantsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantsInCountry> PlantsInCountries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Plants; User=исп-31; Password= 1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Код).HasName("PK_Страны");

            entity.ToTable("Country");

            entity.Property(e => e.Код).ValueGeneratedNever();
            entity.Property(e => e.Материк)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Столица)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.Код).HasName("PK_Растения");

            entity.ToTable("Plant");

            entity.Property(e => e.Код).ValueGeneratedNever();
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Раздел)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Семейство)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<PlantsInCountry>(entity =>
        {
            entity.HasKey(e => new { e.Страна, e.Растение }).HasName("PK_РастенияВСтране");

            entity.ToTable("PlantsInCountry");

            entity.HasOne(d => d.РастениеNavigation).WithMany(p => p.PlantsInCountries)
                .HasForeignKey(d => d.Растение)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_РастенияВСтране_Растения");

            entity.HasOne(d => d.СтранаNavigation).WithMany(p => p.PlantsInCountries)
                .HasForeignKey(d => d.Страна)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_РастенияВСтране_Страны");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
