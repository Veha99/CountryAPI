using country.Models;
using country.Models.Countries;
using country.Services.Countries;
using Microsoft.AspNetCore.Mvc;

namespace country.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CountryController(ICountries countryService) : ControllerBase
{
    [HttpPost("/GetCountryByName")]
    public Task<GetCountryByNameResponse> GetCountryByName(string countryName)
    {
        return countryService.GetCountryByName(countryName);
    }

    [HttpPost("/GetCountryByArea")]
    public Task<GetCountriesByRegionResponse> GetCountryByRegion(CountriesByRegionRequest payload)
    {
        return countryService.GetCountryByRegion(payload);
    }
}