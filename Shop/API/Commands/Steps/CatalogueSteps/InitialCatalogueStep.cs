using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class InitialCatalogueStep : Step
    {
        public override string Message => "Каталог наших товаров:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(ChatId, "");
        }
    }
}
