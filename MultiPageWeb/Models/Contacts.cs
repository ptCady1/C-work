using System.ComponentModel.DataAnnotations;

namespace Multi_PageWebAppCady.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number")]
        public string phoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a address.")]
        public string address { get; set; } = string.Empty;
        public string notes { get; set; } = string.Empty;
    }
}
