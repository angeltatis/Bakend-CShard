﻿// <auto-generated />
using System;
using MasterApiTatis.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MasterApiTatis.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231230180810_migracion1")]
    partial class migracion1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MasterApiTatis.Models.Departamento", b =>
                {
                    b.Property<int>("coddep")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("coddep"));

                    b.Property<string>("desdep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("coddep");

                    b.ToTable("depar");
                });

            modelBuilder.Entity("MasterApiTatis.Models.Grupo", b =>
                {
                    b.Property<int>("codgrup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codgrup"));

                    b.Property<string>("desgrup")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("codgrup");

                    b.ToTable("grup");
                });

            modelBuilder.Entity("MasterApiTatis.Models.Product", b =>
                {
                    b.Property<string>("codpro")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("coddep")
                        .HasColumnType("int");

                    b.Property<int?>("codgrup")
                        .HasColumnType("int");

                    b.Property<int>("codsubgrup")
                        .HasColumnType("int");

                    b.Property<int>("departamentocoddep")
                        .HasColumnType("int");

                    b.Property<string>("despro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("exipro")
                        .HasColumnType("int");

                    b.Property<int>("grupocodgrup")
                        .HasColumnType("int");

                    b.Property<int>("subgrupocodsubgrup")
                        .HasColumnType("int");

                    b.Property<int>("tipoProductcodtippro")
                        .HasColumnType("int");

                    b.Property<int?>("tippro")
                        .HasColumnType("int");

                    b.HasKey("codpro");

                    b.HasIndex("departamentocoddep");

                    b.HasIndex("grupocodgrup");

                    b.HasIndex("subgrupocodsubgrup");

                    b.HasIndex("tipoProductcodtippro");

                    b.ToTable("prod");
                });

            modelBuilder.Entity("MasterApiTatis.Models.ProductUnid", b =>
                {
                    b.Property<int>("codunipro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codunipro"));

                    b.Property<string>("codpro")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("coduni")
                        .HasColumnType("int");

                    b.Property<decimal>("costo1")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("costo2")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("costo3")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("precio1")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("precio2")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("precio3")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("codunipro");

                    b.HasIndex("codpro");

                    b.ToTable("uni_pro");
                });

            modelBuilder.Entity("MasterApiTatis.Models.SubGrupo", b =>
                {
                    b.Property<int>("codsubgrup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codsubgrup"));

                    b.Property<string>("dessubgrup")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("codsubgrup");

                    b.ToTable("subgrup");
                });

            modelBuilder.Entity("MasterApiTatis.Models.TipoProduct", b =>
                {
                    b.Property<int>("codtippro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codtippro"));

                    b.Property<string>("destippro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<bool>("valexi")
                        .HasColumnType("bit");

                    b.HasKey("codtippro");

                    b.ToTable("tippro");
                });

            modelBuilder.Entity("MasterApiTatis.Models.Unid", b =>
                {
                    b.Property<int>("coduni")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("coduni"));

                    b.Property<string>("desuni")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("coduni");

                    b.ToTable("uni");
                });

            modelBuilder.Entity("MasterApiTatis.Models.Product", b =>
                {
                    b.HasOne("MasterApiTatis.Models.Departamento", "departamento")
                        .WithMany()
                        .HasForeignKey("departamentocoddep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterApiTatis.Models.Grupo", "grupo")
                        .WithMany()
                        .HasForeignKey("grupocodgrup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterApiTatis.Models.SubGrupo", "subgrupo")
                        .WithMany()
                        .HasForeignKey("subgrupocodsubgrup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterApiTatis.Models.TipoProduct", "tipoProduct")
                        .WithMany()
                        .HasForeignKey("tipoProductcodtippro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("departamento");

                    b.Navigation("grupo");

                    b.Navigation("subgrupo");

                    b.Navigation("tipoProduct");
                });

            modelBuilder.Entity("MasterApiTatis.Models.ProductUnid", b =>
                {
                    b.HasOne("MasterApiTatis.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("codpro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
