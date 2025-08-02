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

	public (string description, string IconPath) GetWeatherDetails(int code)
		{
			return code switch
			{
				0 => ("Clear Sky", "/images/sunny.png"),
				1 or 2 or 3 => ("Cloudy", "/images/cloudy.png"),
				45 or 48 => ("Fog", "images/fog.png"),
				51 or 53 or 55 => ("Drizzle", "images/drizzle.png"),
				61 or 63 or 65 => ("Rain", "images/rain.png"),
				71 or 73 or 75 => ("Snow", "images/snow.png"),
				80 or 81 or 82 => ("Rain Showers", "images/lightrain.png"),
				95 => ("Thunderstorm", "images/thunderstorm.png"),
				99 => ("Thunderstorm with Hail", "images/hail.png"),
				_ => ("Unknown", "images/unknown.png"),
			};
		}
	}
}