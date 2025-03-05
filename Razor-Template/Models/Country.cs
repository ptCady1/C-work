using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Models
{
    public class Country
    {
        public string countryID { get; set; } = string.Empty;
        public string countryName { get; set; } = string.Empty;
        public Games Games { get; set; } = null!;
        public SportType SportType { get; set; } = null!;
        public string Flag {  get; set; } = string.Empty;
    }
}
