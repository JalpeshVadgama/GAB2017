using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using WeatherBot.Model;

namespace WeatherBot.Helper
{
    public static class LuisHelper
    {
        public async static Task<LuisInformation> ParseTextAsync(string query)
        {
            var APIKey = "Your API Key";
            using (WebClient client = new WebClient())
            {
                var url = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/5d91abd2-5cc9-4cc6-a3e0-0ea472c766eb?subscription-key={APIKey}&verbose=true&timezoneOffset=5.5&spellCheck=true&q={query}";
                var uri = new System.Uri(url);
                var apiResponse = await client.DownloadStringTaskAsync(uri);
                return JsonConvert.DeserializeObject<LuisInformation>(apiResponse);
            }
        }
    }
}