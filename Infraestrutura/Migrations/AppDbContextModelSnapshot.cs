﻿// <auto-generated />
using System;
using Infraestrutura.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dominio.Configuracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("FaixaFinal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("FaixaInicial")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantidadeAprovacoes")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeVistos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Configuracoes");
                });

            modelBuilder.Entity("Dominio.HistoricoAprovacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaId")
                        .HasColumnType("int");

                    b.Property<int>("Operacao")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoAprovacoes");
                });

            modelBuilder.Entity("Dominio.Nota", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaId"), 1L, 1);

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorMercadorias")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("NotaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Papel")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorMaximo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorMinimo")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Dominio.HistoricoAprovacao", b =>
                {
                    b.HasOne("Dominio.Nota", "Nota")
                        .WithMany()
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nota");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
