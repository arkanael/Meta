﻿// <auto-generated />
using System;
using Meta.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meta.Infraestructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meta.Domain.Entities.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Canal")
                        .IsRequired()
                        .HasColumnName("Canal")
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnName("Observacao")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnName("Valor")
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });
#pragma warning restore 612, 618
        }
    }
}
