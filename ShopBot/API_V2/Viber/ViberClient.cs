using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Viber
{
    public class ViberClient : IBotClient
    {
        public Task DeleteWebhookAsync()
        {
            throw new NotImplementedException();
        }

        public Task EditTextMessageAsync(long chatId, int messageId, string text)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetWebhookInfoJsonAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendTextMessageAsync(long chatId, string text, int replyToMessageId = 0, KeyboardMarkup keyboard = null)
        {
            throw new NotImplementedException();
        }

        public Task SetWebhookAsync(string url)
        {
            throw new NotImplementedException();
        }

        public ViberClient(string token)
        {
            //Client = new TelegramBotClient(token);
        }
    }
}
