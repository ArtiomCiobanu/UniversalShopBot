using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "help";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "Используйте следующие команды чтобы:\n" +
                "/help - узнать как этим пользоваться\n" +
                "/order - оформить заказ\n" +
                "/catalogue - получить каталог товаров\n");
        }
    }
}
