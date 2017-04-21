using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using WeatherBot.Model;

namespace WeatherBot.Helper
{
    public class OpenWeatherAPIHelper
    {


        public async Task<WeatherInformation> GetWeatherDataAsync(string city)
        {
            var APIKey = "Your API Key";
            using (WebClient client = new WebClient())
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=json&units=imperial&APPID={APIKey}";
                var uri = new System.Uri(url);
                var apiResponse = await client.DownloadStringTaskAsync(uri);
                return JsonConvert.DeserializeObject<WeatherInformation>(apiResponse);
            }
        }
    }
}