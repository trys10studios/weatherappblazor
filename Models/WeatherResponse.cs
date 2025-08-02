using System.Text.Json.Serialization;

namespace BlazorWeatherApp.Models
{
	public class WeatherResponse
	{
		[JsonPropertyName("current_weather")]
		public WeatherCurrent? CurrentWeather { get; set; }

		public class WeatherCurrent
		{
			[JsonPropertyName("temperature")]
			public double Temperature { get; set; }

			[JsonPropertyName("temperaturef")]
			public double Temperaturef => Math.Round(Temperature * 1.8 + 32);

			[JsonPropertyName("windspeed")]
			public double Windspeed { get; set; }

			[JsonPropertyName("windspeedmph")]
			public double Windspeedmph => Math.Round(Windspeed * 0.621371);

			[JsonPropertyName("weathercode")]
			public int Weathercode { get; set;}
		}

	public string GetWeatherDescription(int code)
		{
			return code switch
			{
				0 => "Clear Sky",
				1 or 2 or 3 => "Cloudy",
				45 or 48 => "Fog",
				51 or 53 or 55 => "Drizzle",
				61 or 63 or 65 => "Rain",
				71 or 73 or 75 => "Snow",
				80 or 81 or 82 => "Rain Showers",
				95 => "Thunderstorm",
				99 => "Thunderstorm with Hail",
				_ => "Unknown",
			};
		}
	}
}