using System.Threading.Tasks;
using country.Models.Countries;
using Microsoft.AspNetCore.Mvc;
using IpCountryApi.Services;

namespace IpCountryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpController : ControllerBase
    {
        private readonly IpInfoService _ipInfoService;

        public IpController(IpInfoService ipInfoService)
        {
            _ipInfoService = ipInfoService;
        }

        [HttpPost("/GetCountryByIP")]
        public Task<IpInfo> GetIpInfo(string ip)
        {
            return IpInfoService.GetIpInfo(ip);
        }
    }
}

