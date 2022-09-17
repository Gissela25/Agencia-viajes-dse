﻿// <auto-generated />
using System;
using Agencia_viajes_dse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agencia_viajes_dse.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220917060204_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Agencia_viajes_dse.Models.AR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ARS");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Costo_Principal")
                        .HasColumnType("float");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TDestino")
                        .HasColumnType("int");

                    b.Property<int>("TLugar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino_AR", b =>
                {
                    b.Property<int>("Id_AR")
                        .HasColumnType("int");

                    b.Property<int>("Id_Destino")
                        .HasColumnType("int");

                    b.HasKey("Id_AR", "Id_Destino");

                    b.HasIndex("Id_Destino");

                    b.ToTable("Destino_ARs");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino_Gastos", b =>
                {
                    b.Property<int>("Id_Gastos")
                        .HasColumnType("int");

                    b.Property<int>("Id_Destino")
                        .HasColumnType("int");

                    b.HasKey("Id_Gastos", "Id_Destino");

                    b.HasIndex("Id_Destino");

                    b.ToTable("Destinos_Gastos");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Gastos_Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gastos_Extras");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Reservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaRegreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Destino")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Destino");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino_AR", b =>
                {
                    b.HasOne("Agencia_viajes_dse.Models.AR", "AR")
                        .WithMany("Destinos_ARs")
                        .HasForeignKey("Id_AR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agencia_viajes_dse.Models.Destino", "Destino")
                        .WithMany("Destinos_ARs")
                        .HasForeignKey("Id_Destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AR");

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino_Gastos", b =>
                {
                    b.HasOne("Agencia_viajes_dse.Models.Destino", "Destino")
                        .WithMany("Destinos_Gastos")
                        .HasForeignKey("Id_Destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agencia_viajes_dse.Models.Gastos_Extra", "Gastos_Extra")
                        .WithMany("Destinos_Gastos")
                        .HasForeignKey("Id_Gastos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Gastos_Extra");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Reservacion", b =>
                {
                    b.HasOne("Agencia_viajes_dse.Models.Destino", "Destinos")
                        .WithMany("Reservaciones")
                        .HasForeignKey("Id_Destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinos");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.AR", b =>
                {
                    b.Navigation("Destinos_ARs");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Destino", b =>
                {
                    b.Navigation("Destinos_ARs");

                    b.Navigation("Destinos_Gastos");

                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("Agencia_viajes_dse.Models.Gastos_Extra", b =>
                {
                    b.Navigation("Destinos_Gastos");
                });
#pragma warning restore 612, 618
        }
    }
}
