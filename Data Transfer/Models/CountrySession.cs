namespace DataTransfer.Models
{
    public class CountrySession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        private ISession session { get; set; }
        public CountrySession(ISession session) => this.session = session;

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count());
        }
        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        public int? GetMyCountriesCount() => session.GetInt32(CountKey);

        public void SetActiveConf(string activeConf) =>
            session.SetString(ConfKey, activeConf);
        public string GetActiveConf() =>
            session.GetString(ConfKey) ?? string.Empty;

        public void SetActiveDiv(string activeDiv) =>
            session.SetString(DivKey, activeDiv);
        public string GetActiveDiv() =>
            session.GetString(DivKey) ?? string.Empty;

        public void RemoveCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }
}
