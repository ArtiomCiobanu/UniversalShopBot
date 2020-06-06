using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps
{
    public abstract class Step : IStep
    {
        public abstract string CommandName { get; }
        public abstract string Message { get; }

        public abstract Task Execute(BotUpdate update, IBotClient client);


        public long ChatId { get; }
        public IStep NextStep { get; set; } = null;
        public IBotClient BotClient { get; }


        public async Task SendMessageAsync(string messageText, int replyToMessageId = 0, KeyboardMarkup keyboardMarkup = null)
        {
            await BotClient.SendTextMessageAsync(ChatId, messageText, replyToMessageId, keyboardMarkup);
        }
        public async Task EditMessageAsync(string messageText, int callbackMessageId, KeyboardMarkup keyboardMarkup = null)
        {
            await BotClient.EditTextMessageAsync(ChatId, callbackMessageId, messageText, keyboardMarkup);
        }

        public Step(BotUpdate update, IBotClient client)
        {
            ChatId = update.ChatId;
            BotClient = client;
        }
        public Step(long chatId, IBotClient client)
        {
            ChatId = chatId;
            BotClient = client;
        }
    }
}
