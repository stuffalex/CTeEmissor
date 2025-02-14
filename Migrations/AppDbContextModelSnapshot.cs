﻿// <auto-generated />
using System;
using CTeEmissor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CTeEmissor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Aliquota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Porcentagem")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Aliquota");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.CTeNota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompraId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorIcms")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.ToTable("Cte");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Carga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("PesoBrutoTotal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PesoUnitario")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Volume")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Carga");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Compra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CargaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeComprador")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorDoFrete")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorDoIcms")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ViagemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CargaId");

                    b.HasIndex("ViagemId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Viagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AliquotaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CepDestino")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CepOrigem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DespesasAdicionais")
                        .HasColumnType("TEXT");

                    b.Property<int>("DistanciaOrigemDestino")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InicioOperacao")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TarifaPorPeso")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AliquotaId");

                    b.ToTable("Viagem");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.CTeNota", b =>
                {
                    b.HasOne("CTeEmissor.Dominio.Model.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Compra", b =>
                {
                    b.HasOne("CTeEmissor.Dominio.Model.Carga", "Carga")
                        .WithMany()
                        .HasForeignKey("CargaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CTeEmissor.Dominio.Model.Viagem", "Viagem")
                        .WithMany()
                        .HasForeignKey("ViagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carga");

                    b.Navigation("Viagem");
                });

            modelBuilder.Entity("CTeEmissor.Dominio.Model.Viagem", b =>
                {
                    b.HasOne("CTeEmissor.Dominio.Model.Aliquota", "Aliquota")
                        .WithMany()
                        .HasForeignKey("AliquotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aliquota");
                });
#pragma warning restore 612, 618
        }
    }
}
