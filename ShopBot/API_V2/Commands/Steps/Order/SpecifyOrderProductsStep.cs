using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class SpecifyOrderProductsStep : OrderStep
    {
        public override string Message => $"Вы выбрали {Data.Category}\nТеперь выберите товар:";

        public override async Task Execute(BotUpdate update, IBotClient client)
        {
            Data.Category = Catalogue.GetCategoryName(update.CallbackData);
            NextStep = null; //new SpecifyPhoneStep(ChatId, BotClient, Data);

            var keyboard = new KeyboardMarkup(KeyboardTools.GetProductsButtonRow(Data.Category, CommandName));
            await EditMessageAsync(Message, update.CallbackMessageId, keyboard);
        }

        public SpecifyOrderProductsStep(BotUpdate update, IBotClient client, OrderData data) : base(update, client, data)
        {

        }
    }
}
