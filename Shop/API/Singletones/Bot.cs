using Shop.API.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Shop.API.Singletones
{
    public static class Bot
    {
        public static readonly TelegramBotClient Client = new TelegramBotClient(AppSettings.Token);

        static List<Command> commandsList = new List<Command>
        {
            new HelloCommand(),
            new StartCommand(),
            new OrderCommand()
        };
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static WebhookInfo WebHookInfo;

        public static async Task SetWebhook()
        {
            await Client.DeleteWebhookAsync();

            await Client.SetWebhookAsync(AppSettings.WebHookUrl);
            WebHookInfo = await Client.GetWebhookInfoAsync();
        }
    }
}
