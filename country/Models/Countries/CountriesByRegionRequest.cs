namespace country.Models;

public class CountriesByRegionRequest
{
    public AreaInfo AreaInfo { get; set; }
}

public class AreaInfo
{
    public string Region { get; set; }
    public string Timezones { get; set; }
}