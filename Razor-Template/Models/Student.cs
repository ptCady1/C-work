using System.ComponentModel.DataAnnotations;

namespace Assignments.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string firstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int? grade { get; set; }

    }
}
