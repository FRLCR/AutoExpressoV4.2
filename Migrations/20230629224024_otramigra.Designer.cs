﻿// <auto-generated />
using System;
using AEFINAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AEFINAL.Migrations
{
    [DbContext(typeof(dbConnect))]
    [Migration("20230629224024_otramigra")]
    partial class otramigra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AEFINAL.Models.Cliente", b =>
                {
                    b.Property<int>("Documento")
                        .HasColumnType("int")
                        .HasColumnName("documento");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correoElectronico");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombrecompleto");

                    b.HasKey("Documento");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AEFINAL.Models.Registro", b =>
                {
                    b.Property<int>("NroOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nroOrden");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroOrden"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<int>("Servicioid")
                        .HasColumnType("int")
                        .HasColumnName("servicioid");

                    b.Property<string>("Vehiculomatricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("vehiculomatricula");

                    b.HasKey("NroOrden");

                    b.HasIndex(new[] { "Servicioid" }, "IX_Registros_servicioid");

                    b.HasIndex(new[] { "Vehiculomatricula" }, "IX_Registros_vehiculomatricula");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("AEFINAL.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<float>("Precio")
                        .HasColumnType("real")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("AEFINAL.Models.Vehiculo", b =>
                {
                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("matricula");

                    b.Property<int>("Clientedocumento")
                        .HasColumnType("int")
                        .HasColumnName("clientedocumento");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("modelo");

                    b.HasKey("Matricula");

                    b.HasIndex(new[] { "Clientedocumento" }, "IX_Vehiculos_clientedocumento");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("AEFINAL.Models.Registro", b =>
                {
                    b.HasOne("AEFINAL.Models.Servicio", "Servicio")
                        .WithMany("Registros")
                        .HasForeignKey("Servicioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AEFINAL.Models.Vehiculo", "VehiculomatriculaNavigation")
                        .WithMany("Registros")
                        .HasForeignKey("Vehiculomatricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servicio");

                    b.Navigation("VehiculomatriculaNavigation");
                });

            modelBuilder.Entity("AEFINAL.Models.Vehiculo", b =>
                {
                    b.HasOne("AEFINAL.Models.Cliente", "ClientedocumentoNavigation")
                        .WithMany("Vehiculos")
                        .HasForeignKey("Clientedocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientedocumentoNavigation");
                });

            modelBuilder.Entity("AEFINAL.Models.Cliente", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("AEFINAL.Models.Servicio", b =>
                {
                    b.Navigation("Registros");
                });

            modelBuilder.Entity("AEFINAL.Models.Vehiculo", b =>
                {
                    b.Navigation("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}
