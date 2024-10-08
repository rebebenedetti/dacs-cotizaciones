﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Servidor.Datos;

#nullable disable

namespace Servidor.Migrations
{
    [DbContext(typeof(MonedaDbContext))]
    [Migration("20240314150158_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Servidor.Dominio.Alerta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MonedaId")
                        .HasColumnType("integer");

                    b.Property<int>("Porcentaje")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MonedaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Alertas");
                });

            modelBuilder.Entity("Servidor.Dominio.Cotizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MonedaBaseId")
                        .HasColumnType("integer");

                    b.Property<int>("MonedaId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("MonedaBaseId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("Servidor.Dominio.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Monedas");
                });

            modelBuilder.Entity("Servidor.Dominio.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MonedaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MonedaId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Servidor.Dominio.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaisId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Servidor.Dominio.Alerta", b =>
                {
                    b.HasOne("Servidor.Dominio.Moneda", "Moneda")
                        .WithMany()
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servidor.Dominio.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moneda");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Servidor.Dominio.Cotizacion", b =>
                {
                    b.HasOne("Servidor.Dominio.Moneda", "MonedaBase")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("MonedaBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonedaBase");
                });

            modelBuilder.Entity("Servidor.Dominio.Pais", b =>
                {
                    b.HasOne("Servidor.Dominio.Moneda", "Moneda")
                        .WithMany("Paises")
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moneda");
                });

            modelBuilder.Entity("Servidor.Dominio.Usuario", b =>
                {
                    b.HasOne("Servidor.Dominio.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Servidor.Dominio.Moneda", b =>
                {
                    b.Navigation("Cotizaciones");

                    b.Navigation("Paises");
                });
#pragma warning restore 612, 618
        }
    }
}
