using country.Models;
using country.Models.Countries;

namespace country.Services.Countries;

public interface ICountries
{
    Task<GetCountryByNameResponse> GetCountryByName(string countryName);
    Task<GetCountriesByRegionResponse> GetCountryByRegion(CountriesByRegionRequest payload);
}