﻿// <auto-generated />
using System;
using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avanade.IT.ChallengeSE.Infra.Data.Migrations
{
    [DbContext(typeof(DbTcContext))]
    [Migration("20220624040335_Initial_Database")]
    partial class Initial_Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Avanade.IT.ChallengeSE.Domain.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("DateAltered")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Image")
                        .HasColumnType("VARCHAR(355)");

                    b.Property<int>("Points")
                        .HasColumnType("INT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<int>("Weight")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Questions", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
