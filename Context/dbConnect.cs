using System;
using System.Collections.Generic;
using AEFINAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AEFINAL.Context;

public partial class dbConnect : DbContext
{
    public dbConnect()
    {
    }

    public dbConnect(DbContextOptions<dbConnect> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AutoExpressoFinalDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Documento);

            entity.Property(e => e.Documento)
                .ValueGeneratedNever()
                .HasColumnName("documento");
            entity.Property(e => e.Apellido).HasColumnName("apellido");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correoElectronico");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.NroOrden);

            entity.HasIndex(e => e.Servicioid, "IX_Registros_servicioid");

            entity.HasIndex(e => e.Vehiculomatricula, "IX_Registros_vehiculomatricula");

            entity.Property(e => e.NroOrden).HasColumnName("nroOrden");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Servicioid).HasColumnName("servicioid");
            entity.Property(e => e.Vehiculomatricula).HasColumnName("vehiculomatricula");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Registros).HasForeignKey(d => d.Servicioid);

            entity.HasOne(d => d.VehiculomatriculaNavigation).WithMany(p => p.Registros).HasForeignKey(d => d.Vehiculomatricula);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Matricula);

            entity.HasIndex(e => e.Clientedocumento, "IX_Vehiculos_clientedocumento");

            entity.Property(e => e.Matricula).HasColumnName("matricula");
            entity.Property(e => e.Clientedocumento).HasColumnName("clientedocumento");
            entity.Property(e => e.Marca).HasColumnName("marca");
            entity.Property(e => e.Modelo).HasColumnName("modelo");

            entity.HasOne(d => d.ClientedocumentoNavigation).WithMany(p => p.Vehiculos).HasForeignKey(d => d.Clientedocumento);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
