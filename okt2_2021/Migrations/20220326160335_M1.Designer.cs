﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace okt2_2021.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220326160335_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prodavnice");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ProdavnicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdavnicaId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.HasOne("Models.Prodavnica", "Prodavnica")
                        .WithMany("proizvodi")
                        .HasForeignKey("ProdavnicaId");

                    b.Navigation("Prodavnica");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Navigation("proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}
