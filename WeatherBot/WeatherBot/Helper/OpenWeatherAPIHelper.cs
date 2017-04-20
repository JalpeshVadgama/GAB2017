using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using WeatherBot.Model;

namespace WeatherBot.Helper
{
    public class OpenWeatherAPIHelper
    {
        readonly string APIKey = "Your api key";

        public async Task<WeatherInformation> GetWeatherDataAsync(string city)
        {
            using (WebClient client = new WebClient())
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=json&units=metric&APPID={this.APIKey}";
                var uri = new System.Uri(url);
                var apiResponse = await client.DownloadStringTaskAsync(uri);
                return JsonConvert.DeserializeObject<WeatherInformation>(apiResponse);
            }
        }
    }
}