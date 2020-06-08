using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class InitialOrderStep : OrderStep
    {
        public override string Message => "Отлично! Выберите категорию:";

        public override async Task Execute(BotUpdate update, IBotClient client)
        {
            NextStep = new SpecifyOrderProductsStep(ChatId, BotClient, Data);

            var keyboard = new KeyboardMarkup(KeyboardTools.GetCategoriesButtonRow(CommandName));
            await SendMessageAsync(Message, keyboardMarkup: keyboard);
        }

        public InitialOrderStep(BotUpdate update, IBotClient client) : base(update, client)
        {

        }
    }
}
