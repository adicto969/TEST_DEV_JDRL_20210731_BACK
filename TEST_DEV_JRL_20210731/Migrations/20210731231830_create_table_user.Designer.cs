﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEST_DEV_JRL_20210731.DataAccess.Model;

namespace TEST_DEV_JRL_20210731.Migrations
{
    [DbContext(typeof(TESTJDRLContext))]
    [Migration("20210731231830_create_table_user")]
    partial class create_table_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TEST_DEV_JRL_20210731.DataAccess.Model.TbPersonasFisica", b =>
                {
                    b.Property<int>("IdPersonaFisica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("ApellidoMaterno")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ApellidoPaterno")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rfc")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("RFC");

                    b.Property<int?>("UsuarioAgrega")
                        .HasColumnType("int");

                    b.HasKey("IdPersonaFisica");

                    b.ToTable("Tb_PersonasFisicas");
                });

            modelBuilder.Entity("TEST_DEV_JRL_20210731.DataAccess.Model.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
