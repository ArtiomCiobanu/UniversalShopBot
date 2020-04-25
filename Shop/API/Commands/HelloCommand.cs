using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var chatId = update.Message.Chat.Id;
            var messageId = update.Message.MessageId;

            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}
