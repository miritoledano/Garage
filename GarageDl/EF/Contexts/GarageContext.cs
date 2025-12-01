using System;
using System.Collections.Generic;
using GarageDB.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageDB.EF.Contexts;

public partial class GarageContext : DbContext
{
    public GarageContext()
    {
    }

    public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Garage> Garages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5S6EPEU\\SQLEXPRESS;Initial Catalog=GarageDb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Garage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Garage__DED88B1CE52AD3EB");

            entity.ToTable("Garage");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.CodMiktzoa).HasColumnName("cod_miktzoa");
            entity.Property(e => e.CodSugMosah).HasColumnName("cod_sug_mosah");
            entity.Property(e => e.Ktovet)
                .HasMaxLength(255)
                .HasColumnName("ktovet");
            entity.Property(e => e.MenahelMiktzoa)
                .HasMaxLength(255)
                .HasColumnName("menahel_miktzoa");
            entity.Property(e => e.Miktzoa)
                .HasMaxLength(255)
                .HasColumnName("miktzoa");
            entity.Property(e => e.Mikud).HasColumnName("mikud");
            entity.Property(e => e.MisparMosah).HasColumnName("mispar_mosah");
            entity.Property(e => e.RashamHavarot).HasColumnName("rasham_havarot");
            entity.Property(e => e.ShemMosah)
                .HasMaxLength(255)
                .HasColumnName("shem_mosah");
            entity.Property(e => e.SugMosah)
                .HasMaxLength(255)
                .HasColumnName("sug_mosah");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
            entity.Property(e => e.Testime)
                .HasMaxLength(255)
                .HasColumnName("TESTIME");
            entity.Property(e => e.Yishuv)
                .HasMaxLength(255)
                .HasColumnName("yishuv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
