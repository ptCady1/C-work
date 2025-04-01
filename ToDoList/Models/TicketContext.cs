using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ToDoList.Models
{
	public class TicketContext : DbContext
	{
		public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

		public DbSet<Ticket> Tickets { get; set; } = null!;
		public DbSet<Status> Statuses { get; set; } = null!;

		public DbSet<Point> Points { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Point>().HasData(
				new Point { PointId = "easy", PointValues = 1 },
				new Point { PointId = "medium", PointValues = 5 },
				new Point { PointId = "hard", PointValues = 10 }
				);
			modelBuilder.Entity<Status>().HasData(
				new Status { StatusId = "todo", Name = "To-Do" },
				new Status { StatusId = "inprog", Name = "In-Progress" },
				new Status { StatusId = "qa", Name = "Quality Assurance" },
				new Status { StatusId = "don", Name = "Done" }
				);
		}
	}
}
