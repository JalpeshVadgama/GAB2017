using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;
using WeatherBot.Helper;

namespace WeatherBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var helper = new OpenWeatherAPIHelper();
            var weatherInforamion = await helper.GetWeatherDataAsync(activity.Text ?? string.Empty);
            await context.PostAsync(weatherInforamion.visibility.ToString());

            //// calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            //// return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}