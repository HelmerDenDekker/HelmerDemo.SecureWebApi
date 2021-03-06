namespace HelmerDemo.SecureWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using SecureDemoApi.CommonCode.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
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
