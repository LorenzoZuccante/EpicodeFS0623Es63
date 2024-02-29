﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ScarpaMondo.Migrations
{
    [DbContext(typeof(ScarpaMondoContext))]
    [Migration("20240228161029_AddIsDeletedToArticoli")]
    partial class AddIsDeletedToArticoli
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScarpaMondo.Models.Articolo", b =>
                {
                    b.Property<int>("ArticoloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticoloId"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImmagineAggiuntiva1Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImmagineAggiuntiva2Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImmagineCopertinaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InVetrina")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ArticoloId");

                    b.ToTable("Articoli");
                });
#pragma warning restore 612, 618
        }
    }
}
