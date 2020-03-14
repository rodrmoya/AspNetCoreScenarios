using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContainerServices.Shared
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

		public string Summary { get; set; }

		public static async Task<WeatherForecast> FromUrlAsync (string url)
		{
			using var _httpClient = new HttpClient ();
			var response = await _httpClient.GetAsync (url, HttpCompletionOption.ResponseHeadersRead);
			response.EnsureSuccessStatusCode ();
			var data = await response.Content.ReadAsStringAsync ();
			return JsonConvert.DeserializeObject<WeatherForecast> (data);
		}
	}
}
