using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDoList.Models
{
	public class Ticket
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int SprintNum { get; set; }

		public string PointId { get; set; } = string.Empty;
		[ValidateNever]
		public Point Point { get; set; } = null!;

		public string StatusId { get; set; } = string.Empty;
		[ValidateNever]
		public Status Status { get; set; } = null!;
	}
}
