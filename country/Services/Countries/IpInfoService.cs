using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using country.Models;
using country.Models.Countries;

namespace IpCountryApi.Services
{
    public class IpInfoService
    {
        private static HttpClient _httpClient;

        public IpInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static async Task<IpInfo> GetIpInfo(string ip)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://ipinfo.io/{ip}/json");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var ipInfo = JsonSerializer.Deserialize<IpInfo>(json);

                // Check if ipInfo is null or Country is empty
                if (ipInfo == null || string.IsNullOrEmpty(ipInfo.Country))
                {
                    return new IpInfo()
                    {
                        Country = "Country information not available"
                    };
                }
                
                return new IpInfo()
                {
                    Country = ipInfo.Country
                };
            }
            catch (Exception ex)
            {
                return new IpInfo()
                {
                    Country = "Error occurred while fetching country information"
                };
            }
        }
    }
}