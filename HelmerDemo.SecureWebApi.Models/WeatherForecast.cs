namespace SecureDemoApi.CommonCode.Models
{
    using System;

    /// <summary>
    /// The weather forecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in degrees Celsius.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// The temperature in degrees Fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }
    }
}
