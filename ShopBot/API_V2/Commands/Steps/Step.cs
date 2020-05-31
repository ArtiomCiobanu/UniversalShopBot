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


        public async Task EditMessageAsync(string messageText, int callbackMessageId)
        {
            await BotClient.EditTextMessageAsync(ChatId, callbackMessageId, messageText);
        }
        public async Task SendMessageAsync(string messageText)
        {
            await BotClient.SendTextMessageAsync(ChatId, messageText);
        }

        public Step()
        {

        }
        public Step(long chatId)
        {
            ChatId = chatId;
        }
        public Step(long chatId, IBotClient client)
        {
            ChatId = chatId;
            BotClient = client;
        }
    }
}
