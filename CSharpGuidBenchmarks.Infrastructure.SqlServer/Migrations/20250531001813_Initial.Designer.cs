﻿// <auto-generated />
using System;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Infrastructure.SqlServer;
using CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20250531001813_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities.GuidV4Bin16ClusteredPkEntity", b =>
                {
                    b.Property<byte[]>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("GuidV4Bin16ClusteredPkEntities");
                });

            modelBuilder.Entity("CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities.GuidV4ClusteredPkEntity", b =>
                {
                    b.Property<Guid>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("GuidV4ClusteredPkEntities");
                });

            modelBuilder.Entity("CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities.GuidV7Bin16ClusteredPkEntity", b =>
                {
                    b.Property<byte[]>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("GuidV7Bin16ClusteredPkEntities");
                });

            modelBuilder.Entity("CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities.GuidV7ClusteredPkEntity", b =>
                {
                    b.Property<Guid>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("GuidV7ClusteredPkEntities");
                });

            modelBuilder.Entity("CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkEntity", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrimaryKey"));

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("IntClusteredPrimaryKeyEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
