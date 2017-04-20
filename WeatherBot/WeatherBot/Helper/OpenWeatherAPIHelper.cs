using Newtonsoft.Json;
using System.Net;
using WeatherBot.Model;

namespace WeatherBot.Helper
{
    public class OpenWeatherAPIHelper
    {
        readonly string APIKey = "Your api key";

        public WeatherInformation GetWeatherData(string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=json&units=metric&APPID={this.APIKey}";

            using (WebClient client = new WebClient())
            {
                var apiResponse = client.DownloadString(url);
                var weatherInformation = JsonConvert.DeserializeObject<WeatherInformation>(apiResponse);
                return weatherInformation;
            }
        }
    }
}