using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.RapidApi.Models;

namespace Udemy.RapidApi.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
                        Headers =
            {
                { "x-rapidapi-key", "f98194c225msh0e76c5ec933fe45p10715ejsn15ca207622ff" },
                { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.CityTemp = values.data.temp;
                return View();
            }

        }
    }
}
