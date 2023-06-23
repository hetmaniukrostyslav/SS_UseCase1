using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS_UseCase1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SS_UseCase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCountriesAsync([FromQuery] string? arg1, [FromQuery] int? arg2, [FromQuery] string? arg3)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var responseJson = await httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
            return Ok(DeserializeJsonToCountries(responseJson));
        }


        public static List<Country> DeserializeJsonToCountries(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException(json);
            }
            return JsonSerializer.Deserialize<List<Country>>(json);
        }
    }
}

