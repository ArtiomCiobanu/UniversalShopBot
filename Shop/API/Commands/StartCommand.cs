﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "Здравствуйте!\n" +
                "Используйте следующие команды чтобы:\n" +
                "/help - помощь\n" +
                "/order - оформить заказ\n" +
                "/catalogue - получить каталог товаров\n");
        }
    }
}
