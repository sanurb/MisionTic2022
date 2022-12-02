﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MudBlazorTest.Server.Data;

#nullable disable

namespace MudBlazorTest.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221129153425_quickfix1")]
    partial class quickfix1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MudBlazorTest.Shared.Perro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Afiliacion")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropietarioId")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropietarioId");

                    b.ToTable("Perros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Afiliacion = true,
                            Color = "Blanco con dorado",
                            Nombre = "Isis",
                            PropietarioId = 1,
                            Raza = "Beagle",
                            Sexo = "Hembra"
                        },
                        new
                        {
                            Id = 2,
                            Afiliacion = false,
                            Color = "Blanco con dorado",
                            Nombre = "Valentino",
                            PropietarioId = 2,
                            Raza = "Bulldog",
                            Sexo = "Macho"
                        });
                });

            modelBuilder.Entity("MudBlazorTest.Shared.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Urbano Rivadeneira",
                            Direccion = "Calle 63# 4-52, Cali, Valle",
                            Nombres = "David Santiago",
                            Telefono = "+573158880482"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Urbano Rivadeneira",
                            Direccion = "Calle 63# 4-52, Cali, Valle",
                            Nombres = "Sofia",
                            Telefono = "+573168880482"
                        });
                });

            modelBuilder.Entity("MudBlazorTest.Shared.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veterinarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Perez",
                            Nombres = "Pepito",
                            TarjetaProfesional = "123456",
                            Telefono = "+573158880482"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Gomez",
                            Nombres = "Juan",
                            TarjetaProfesional = "953456",
                            Telefono = "+573168880482"
                        });
                });

            modelBuilder.Entity("MudBlazorTest.Shared.Perro", b =>
                {
                    b.HasOne("MudBlazorTest.Shared.Propietario", "Propietario")
                        .WithMany()
                        .HasForeignKey("PropietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");
                });
#pragma warning restore 612, 618
        }
    }
}
