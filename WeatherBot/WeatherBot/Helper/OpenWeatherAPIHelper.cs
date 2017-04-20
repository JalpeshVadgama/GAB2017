using System.Net;

namespace WeatherBot.Helper
{

    public class OpenWeatherAPIHelper
    {
        readonly string APIKey = "your api key";

        public string Repsonse { get; set; }

        public void GetWeatherData(string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=json&units=metric&APPID={this.APIKey}";

            using (WebClient client = new WebClient())
            {
                this.Repsonse = client.DownloadString(url);
            }
        }
    }
}