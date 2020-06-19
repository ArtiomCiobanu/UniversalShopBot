using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class DescribeProductStep : CatalogueStep
    {
        public override string Message => "Это описание невероятного";
        public OrderData Data { get; private set; } = new OrderData();

        private async Task BackAction(BotUpdate update, IBotClient client)
        {
            var next = new InitialCatalogueStep(ChatId, client);
            await next.Execute(update, client);
            NextStep = next.NextStep;
        }

        public override async Task DefaultAction(BotUpdate update, IBotClient client)
        {
            Data.Product = Catalog.GetProductName(update.CallbackData);
            var backButton = new KeyboardMarkup(KeyboardTools.GetOrderAndBackButtons(Data.Product, CommandName));

            NextStep = new ReturnOrOrderStep(Data, update.CallbackData, ChatId, client);

            await EditMessageAsync($"{Message} {Data.Product}", update.CallbackMessageId, backButton);
        }

        public DescribeProductStep(long chatId, IBotClient client, string selectedCategory) :
            base(chatId, client)
        {
            Data.Category = selectedCategory;

            CallbackActions.Add("Back", BackAction);
        }
    }
}
