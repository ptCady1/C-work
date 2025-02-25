using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        StudentID = 1,
                        firstName = "Billy",
                        LastName = "Bob",
                        grade = 5,
                    },
                    new Student
                    {
                        StudentID = 2,
                        firstName = "Mike",
                        LastName = "Jones",
                        grade = 7,
                    },
                    new Student
                    {
                        StudentID = 3,
                        firstName = "Alice",
                        LastName = "Mason",
                        grade = 9,
                    },
                    new Student
                    {
                        StudentID = 4,
                        firstName = "Jack",
                        LastName = "Thomas",
                        grade = 2,
                    }
                    );
        }
    }
}
