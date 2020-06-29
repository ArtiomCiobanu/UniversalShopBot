using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void ExecuteMainAction(BotUpdate update, IBotClient client)
        {
            var chatId = update.ChatId;

            await client.SendTextMessageAsync(chatId,
                "Здравствуйте!\n");
            await client.SendTextMessageAsync(chatId,
                "Используйте следующие команды чтобы:\n" +
                "/help - помощь\n" +
                "/order - оформить заказ\n" +
                "/catalogue - получить каталог товаров\n");
        }
    }
}
