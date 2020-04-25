using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var chatId = update.Message.Chat.Id;

            await client.SendTextMessageAsync(chatId, "Здравствуйте!");
        }
    }
}
