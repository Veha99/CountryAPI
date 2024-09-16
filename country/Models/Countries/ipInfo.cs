using System.Text.Json.Serialization;

namespace country.Models.Countries;

public class IpInfo
{
    [JsonPropertyName("country")]
    public string Country { get; set; }
}