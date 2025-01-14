﻿// <auto-generated />
using System;
using MessageHawk.Inbox.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageHawk.Inbox.Infrastructure.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20250107192747_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MessageHawk.Inbox.Domain.Entities.Envelope", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Envelopes");
                });
#pragma warning restore 612, 618
        }
    }
}
