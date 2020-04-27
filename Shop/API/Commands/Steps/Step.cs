using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps
{
    public abstract class Step : IStep
    {
        public long ChatId { get; }
        public abstract string Message { get; }
        public IStep NextStep { get; set; } = null;
        public TelegramBotClient BotClient { get; }

        public abstract Task Execute(Update update, TelegramBotClient client);

        public Task SendMessage(string message, InlineKeyboardMarkup replyMarkup = null)
        {
            throw new NotImplementedException();
        }
        public Task EditMessage(string message, InlineKeyboardMarkup replyMarkup = null)
        {
            throw new NotImplementedException();
        }

        public Step()
        {

        }
        public Step(long chatId)
        {
            ChatId = chatId;
        }
        public Step(long chatId, TelegramBotClient client)
        {
            ChatId = chatId;
            BotClient = client;
        }
    }
}
