using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void Execute(BotUpdate update, IBotClient client)
        {
            await client.SendTextMessageAsync(update.ChatId, "Hello!", replyToMessageId: update.MessageId);
        }
    }
}
