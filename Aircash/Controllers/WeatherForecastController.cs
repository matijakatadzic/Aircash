using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aircash.Business.HttpClientService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aircash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAmadeusHotelHttpClientService _httpClientService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAmadeusHotelHttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _httpClientService.GetDataAsync();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
