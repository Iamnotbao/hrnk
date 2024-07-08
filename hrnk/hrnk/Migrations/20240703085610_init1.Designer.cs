﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hrnk.Data;

#nullable disable

namespace hrnk.Migrations
{
    [DbContext(typeof(hrnkDbcontext))]
    [Migration("20240703085610_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hrnk.Models.User", b =>
                {
                    b.Property<long>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("userid"));

                    b.Property<byte[]>("hash_password")
                        .IsRequired()
                        .HasColumnType("binary(32)")
                        .HasColumnName("hash_password");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("role");

                    b.Property<DateTime?>("user_create_at")
                        .HasColumnType("datetime2")
                        .HasColumnName("user_create_at");

                    b.Property<string>("user_create_by")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_create_by");

                    b.Property<DateTime?>("user_update_at")
                        .HasColumnType("datetime2")
                        .HasColumnName("user_update_at");

                    b.Property<string>("user_update_by")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_update_by");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("userid");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
