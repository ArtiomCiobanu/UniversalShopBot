using Newtonsoft.Json;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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

        public async Task SendTextMessageAsync(long chatId, string text, int replyToMessageId = 0, KeyboardMarkup keyboard = null)
        {
            InlineKeyboardMarkup keyboardMarkup = GetInlineKeyboardMarkup(keyboard);
            await Client.SendTextMessageAsync(chatId, text, replyToMessageId: replyToMessageId, replyMarkup: keyboardMarkup);
        }
        public async Task EditTextMessageAsync(long chatId, int messageId, string messageText, KeyboardMarkup keyboard = null)
        {
            InlineKeyboardMarkup keyboardMarkup = GetInlineKeyboardMarkup(keyboard);
            await Client.EditMessageTextAsync(chatId, messageId, messageText, replyMarkup: keyboardMarkup);
        }

        private InlineKeyboardMarkup GetInlineKeyboardMarkup(KeyboardMarkup keyboardMarkup)
        {
            if (keyboardMarkup != null)
            {
                var inlineKeyboard = keyboardMarkup.KeyboardButtons.Select(
                    buttonArray => buttonArray.Select(buttonInfo => new InlineKeyboardButton()
                    {
                        CallbackData = buttonInfo.CallbackData,
                        Text = buttonInfo.Text
                    }).ToArray()
                ).ToArray();

                InlineKeyboardMarkup markup = new InlineKeyboardMarkup(inlineKeyboard);

                return markup;
            }
            else
            {
                return null;
            }
        }

        public TelegramClient(string token)
        {
            Client = new TelegramBotClient(token);
        }
    }
}
