﻿// <auto-generated />
using Assignments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignments.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignments.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            LastName = "Bob",
                            firstName = "Billy",
                            grade = 5
                        },
                        new
                        {
                            StudentID = 2,
                            LastName = "Jones",
                            firstName = "Mike",
                            grade = 7
                        },
                        new
                        {
                            StudentID = 3,
                            LastName = "Mason",
                            firstName = "Alice",
                            grade = 9
                        },
                        new
                        {
                            StudentID = 4,
                            LastName = "Thomas",
                            firstName = "Jack",
                            grade = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
