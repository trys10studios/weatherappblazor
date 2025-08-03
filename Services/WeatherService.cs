using BlazorWeatherApp.Models;
using System.Net.Http.Json;

namespace BlazorWeatherApp.Services

{
	public class WeatherService
	{
		private readonly HttpClient _http;

		public WeatherService(HttpClient http)
		{
			_http = http;
		}
		public async Task<WeatherResponse?> GetWeatherAsync(double lat, double lon)
		{
			var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true&cache_bust ={ Guid.NewGuid()}";

			var response = await _http.GetFromJsonAsync<WeatherResponse>(url);

			try
			{
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"WeatherService error: {ex.Message}");
				return null;
			}
		}

	}
}