using System.ComponentModel.DataAnnotations;

namespace DataTransfer.Models
{
    public class SportType
    {
        public string SportTypeID { get; set; } = string.Empty;
        public string SportName { get; set;} = string.Empty;
    }
}
