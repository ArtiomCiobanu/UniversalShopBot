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
            NextStep = null; //new SpecifyOrderProductsStep(ChatId, BotClient, Data);

            //var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetCategoriesButtonRow(CommandName));
            var keyboard = new KeyboardMarkup(KeyboardTools.GetCategoriesButtonRow(CommandName));

            await SendMessageAsync(Message, keyboard: keyboard);
        }

        public InitialOrderStep(BotUpdate update, IBotClient client) : base(update, client)
        {

        }
        public InitialOrderStep(long chatId, string fullName, IBotClient client) : base(chatId, fullName, client)
        {
        }
        public InitialOrderStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
