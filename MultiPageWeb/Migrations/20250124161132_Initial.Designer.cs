﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Multi_PageWebAppCady.Models;

#nullable disable

namespace Multi_PageWebAppCady.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20250124161132_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Multi_PageWebAppCady.Models.Contacts", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Name = "Jim",
                            address = "0001 N Walter Dr",
                            notes = "D&D buddy",
                            phoneNumber = "555-111-2222"
                        },
                        new
                        {
                            ContactId = 2,
                            Name = "Jane",
                            address = "0002 S Ben St",
                            notes = "Cafe owner",
                            phoneNumber = "555-222-1111"
                        },
                        new
                        {
                            ContactId = 3,
                            Name = "Bill",
                            address = "0003 W Walker St",
                            notes = "the pizza guy",
                            phoneNumber = "555-333-7777"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
