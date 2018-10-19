﻿// <auto-generated />
using System;
using CodeAnalysisReport.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeAnalysisReport.Database.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    [Migration("20181019130842_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeAnalysisReport.Database.Model.CodeAnalysis", b =>
                {
                    b.Property<long>("CodeAnalysisId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaminhoArquivo")
                        .HasMaxLength(255);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("DataExecucao");

                    b.Property<string>("Descricao");

                    b.Property<string>("Dll")
                        .HasMaxLength(70);

                    b.Property<int>("LinhaCodigo");

                    b.Property<string>("Projeto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Severidade")
                        .HasMaxLength(20);

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CodeAnalysisId");

                    b.ToTable("CodeAnalysis");
                });
#pragma warning restore 612, 618
        }
    }
}