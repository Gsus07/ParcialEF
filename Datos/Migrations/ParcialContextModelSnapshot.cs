﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParcialContext))]
    partial class ParcialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Apoyo", b =>
                {
                    b.Property<string>("IdApoyo")
                        .HasColumnType("varchar(5)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<string>("ModalidadApoyo")
                        .HasColumnType("varchar(17)");

                    b.Property<decimal>("ValorApoyo")
                        .HasColumnType("decimal");

                    b.HasKey("IdApoyo");

                    b.ToTable("Apoyo");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("ApoyoIdApoyo")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Departamento")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Edad")
                        .HasColumnType("decimal");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Identificacion");

                    b.HasIndex("ApoyoIdApoyo");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.HasOne("Entidad.Apoyo", "Apoyo")
                        .WithMany()
                        .HasForeignKey("ApoyoIdApoyo");
                });
#pragma warning restore 612, 618
        }
    }
}