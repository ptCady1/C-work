using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
	public class Ticket
	{
		public int Id { get; set; }
		[Required (ErrorMessage = "Please input a name")]
        [StringLength(30)]
		public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please input a description")]
        [StringLength(30)]
        public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "A sprint number must be input.")]
		[Sprint]
		public int SprintNum { get; set; }
        [Required(ErrorMessage = "Please chose a point value.")]
        public string PointId { get; set; } = string.Empty;
		[ValidateNever]
		public Point Point { get; set; } = null!;

        [Required(ErrorMessage = "Please current status.")]
		[StringLength(30)]
        public string StatusId { get; set; } = string.Empty;
		[ValidateNever]
		public Status Status { get; set; } = null!;
	}
}
