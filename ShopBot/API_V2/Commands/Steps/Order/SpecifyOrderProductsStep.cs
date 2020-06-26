using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class SpecifyOrderProductsStep : OrderStep
    {
        public override string Message => $"Вы выбрали {Data.Category}\nТеперь выберите товар:";

        public override async Task MainAction(BotUpdate update, IBotClient clien)
        {
            Data.Category = Catalog.GetCategoryName(update.CallbackData.Split()[1]);
            NextStep = new SpecifyPhoneStep(ChatId, BotClient, Data);

            var keyboard = new KeyboardMarkup(KeyboardTools.GetProductsButtonRow(Data.Category, CommandName));
            await EditMessageAsync(Message, update.CallbackMessageId, keyboard);
        }

        public SpecifyOrderProductsStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}
