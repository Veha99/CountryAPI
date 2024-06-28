using country.Models;
using country.Models.Countries;

namespace country.Services.Countries;

public class CountryService: ICountries
{
    private readonly HttpClient _httpClient;
    
    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    
    public async Task<GetCountryByNameResponse> GetCountryByName(string countryName)
    {
        try
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/name/" + countryName);
            if (!response.IsSuccessStatusCode)
            {
                return new GetCountryByNameResponse();
            }
            var dataSourceCountries = await response.Content.ReadFromJsonAsync<List<Root>>();
            if (dataSourceCountries == null || dataSourceCountries.Count == 0) return new GetCountryByNameResponse();
            var firstCountry = dataSourceCountries.First();
            var country = MapToCountry(firstCountry);
            return new GetCountryByNameResponse()
            {
                CountryInfo = country
            };
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            return new GetCountryByNameResponse();
        }
    }
    
    public async Task<GetCountriesByRegionResponse> GetCountryByRegion(CountriesByRegionRequest payload)
    {
        try
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/region/" + payload.AreaInfo.Region);
            if (!response.IsSuccessStatusCode)
            {
                return new GetCountriesByRegionResponse();
            }

            var countries = await response.Content.ReadFromJsonAsync<List<Root>>();
            if (countries == null) return new GetCountriesByRegionResponse();
            var newCountriesList = new List<CountryInfo>();

            foreach (var item in countries)
            {
                newCountriesList.Add(MapToCountry(item));
            }
            return new GetCountriesByRegionResponse()
            {
                AreaInfo = newCountriesList
            };
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            return new GetCountriesByRegionResponse();
        }
    }
    private static CountryInfo MapToCountry(Root country)
    {
        return new CountryInfo()
        {
            Alpha2Code = country?.cca2 ?? "",
            CallingCodes = $"{country?.idd?.root ?? ""}{country?.idd?.suffixes?.FirstOrDefault() ?? ""}",
            Capital = country?.capital?.FirstOrDefault() ?? "",
            FlagUrl = country?.flags?.png ?? "",
            Name = country?.name?.official ?? "",
            Timezones = country?.timezones?.FirstOrDefault() ?? "",
        };
    }
}