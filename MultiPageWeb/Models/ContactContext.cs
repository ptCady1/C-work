using Microsoft.EntityFrameworkCore;

namespace Multi_PageWebAppCady.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contacts> Contact { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contacts>().HasData(
                new Contacts
                {
                    ContactId = 1,
                    Name = "Jim",
                    phoneNumber = "555-111-2222",
                    address = "0001 N Walter Dr",
                    notes = "D&D buddy",
                },
                new Contacts
                {
                    ContactId = 2,
                    Name = "Jane",
                    phoneNumber = "555-222-1111",
                    address = "0002 S Ben St",
                    notes = "Cafe owner",
                },
                new Contacts
                {
                    ContactId = 3,
                    Name = "Bill",
                    phoneNumber = "555-333-7777",
                    address = "0003 W Walker St",
                    notes = "the pizza guy",
                }

                );

        }
    }
}
