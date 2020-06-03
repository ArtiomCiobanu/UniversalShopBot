using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "help";

        public override async void Execute(BotUpdate update, IBotClient client)
        {
            var chatId = update.ChatId;

            await client.SendTextMessageAsync(chatId,
                "Используйте следующие команды чтобы:\n" +
                "/help - помощь\n" +
                "/order - оформить заказ\n" +
                "/catalogue - получить каталог товаров\n");
        }
    }
}
