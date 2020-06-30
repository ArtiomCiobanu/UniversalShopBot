using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class DescribeCatalogueProductStep : CatalogueStep
    {
        public override string Message => "Это описание невероятного";

        private async Task BackAction(BotUpdate update, IBotClient client)
        {
            var next = new InitialCatalogueStep(ChatId, client);
            await next.Execute(update, client);
            NextStep = next.NextStep;
        }

        public override async Task DefaultAction(BotUpdate update, IBotClient client)
        {
            Data.ProductId = update.CallbackData.Split()[1];

            var backButton = new KeyboardMarkup(KeyboardTools.GetOrderAndBackButtons(Data.ProductName, CommandName));

            NextStep = new ReturnOrOrderCatalogueStep(Data, ChatId, client);

            await EditMessageAsync($"{Message} {Data.ProductName}", update.CallbackMessageId, backButton);
        }

        public DescribeCatalogueProductStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {
            CallbackActions.Add("Back", BackAction);
        }
    }
}
