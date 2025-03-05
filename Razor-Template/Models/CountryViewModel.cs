namespace Assignments.Models
{
    public class CountryViewModel
    {
        public string ActiveConf { get; set; } = "all";
        public string ActiveDiv { get; set; } = "all";

        public List<Country> Countries { get; set;} = new List<Country>();

        public List<Games> Game { get; set; } = new List<Games>();
        public List<SportType> SportsTypes { get; set; } = new List<SportType>();

        public string CheckActiveConf(string c)=> c.ToLower() == ActiveConf.ToLower() ? "active" : "";

        public string CheckActiveDiv(string d) => d.ToLower() == ActiveDiv.ToLower() ? "active" : "";
    }
}
