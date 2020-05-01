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
        public IStep NextStep { get; set; } = null;
        public TelegramBotClient BotClient { get; }

        public abstract string CommandName { get; }
        public abstract string Message { get; }

        public abstract Task Execute(Update update, TelegramBotClient client);

        public async Task SendMessageAsync(string message, InlineKeyboardMarkup replyKeyboardMarkup = null)
        {
            await BotClient.SendTextMessageAsync(ChatId, message, replyMarkup: replyKeyboardMarkup);
        }
        public async Task EditMessageAsync(string message, CallbackQuery callback, InlineKeyboardMarkup replyKeyboardMarkup = null)
        {
            await BotClient.EditMessageTextAsync(ChatId, callback.Message.MessageId, message, replyMarkup: replyKeyboardMarkup);
        }

        public Step()
        {

        }
        public Step(long chatId)
        {
            ChatId = chatId;
        }
        public Step(Message message)
        {
            ChatId = message.Chat.Id;
        }
        public Step(Message message, TelegramBotClient client)
        {
            ChatId = message.Chat.Id;
            BotClient = client;
        }
        public Step(long chatId, TelegramBotClient client)
        {
            ChatId = chatId;
            BotClient = client;
        }
    }
}
