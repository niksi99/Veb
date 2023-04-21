﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace jan2021.Migrations
{
    [DbContext(typeof(GradContext))]
    partial class GradContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("Models.MeteoroloskiPodaci", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("GradID")
                        .HasColumnType("int");

                    b.Property<int>("Mesec")
                        .HasColumnType("int");

                    b.Property<int>("brojSuncanihDana")
                        .HasColumnType("int");

                    b.Property<int>("kolicinaPadavina")
                        .HasColumnType("int");

                    b.Property<int>("prosecnaDnevnaTemperatura")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("Podaci");
                });

            modelBuilder.Entity("Models.MeteoroloskiPodaci", b =>
                {
                    b.HasOne("Models.Grad", "Grad")
                        .WithMany("podaci")
                        .HasForeignKey("GradID");

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("Models.Grad", b =>
                {
                    b.Navigation("podaci");
                });
#pragma warning restore 612, 618
        }
    }
}
