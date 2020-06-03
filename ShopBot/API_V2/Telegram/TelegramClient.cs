using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API_V2.Telegram
{
    public class TelegramClient : IBotClient
    {
        TelegramBotClient Client { get; set; }

        public Task DeleteWebhookAsync() => Client.DeleteWebhookAsync();
        public async Task<string> GetWebhookInfoJsonAsync()
        {
            WebhookInfo info = await Client.GetWebhookInfoAsync();

            return JsonConvert.SerializeObject(info);
        }
        public Task SetWebhookAsync(string url) => Client.SetWebhookAsync(url);

        public async Task SendTextMessageAsync(long chatId, string text, int replyToMessageId)
        {
            await Client.SendTextMessageAsync(chatId, text, replyToMessageId: replyToMessageId);
        }
        public async Task EditTextMessageAsync(long chatId, int messageId, string messageText)
        {
            await Client.EditMessageTextAsync(chatId, messageId, messageText);
        }

        public TelegramClient(string token)
        {
            Client = new TelegramBotClient(token);
        }
    }
}
