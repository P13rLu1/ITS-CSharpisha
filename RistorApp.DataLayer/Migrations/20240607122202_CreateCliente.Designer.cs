﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RistorApp.DataLayer;

#nullable disable

namespace RistorApp.DataLayer.Migrations
{
    [DbContext(typeof(RistoranteDbContext))]
    [Migration("20240607122202_CreateCliente")]
    partial class CreateCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RistorApp.DataLayer.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cognome");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_nascita");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("RistorApp.DataLayer.Models.Prenotazione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataPrenotazione");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<int>("IdTavolo")
                        .HasColumnType("int")
                        .HasColumnName("idTavolo");

                    b.HasKey("Id");

                    b.ToTable("prenotazione");
                });

            modelBuilder.Entity("RistorApp.DataLayer.Models.Tavolo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroPersone")
                        .HasColumnType("int")
                        .HasColumnName("numero_persone");

                    b.Property<string>("Posizione")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("posizione");

                    b.HasKey("Id");

                    b.ToTable("tavoli");
                });
#pragma warning restore 612, 618
        }
    }
}
