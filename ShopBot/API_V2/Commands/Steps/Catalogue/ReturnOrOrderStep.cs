using ShopBot.API_V2.Commands.Steps.Order;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class ReturnOrOrderStep : CatalogueStep
    {
        public override string Message => null;
        public string SelectedCategoryId { get; }
        public OrderData Data { get; private set; }

        public override async Task Execute(BotUpdate update, IBotClient client)
        {
            IStep next = null;
            if (update.CallbackData == "catalogue Back")
            {
                next = new ShowCatalogueProductsStep(SelectedCategoryId, ChatId, client);
            }
            else if (update.CallbackData == "catalogue Order")
            {
                Data.SetFullName(update.FullName);
                update.CallbackData = SelectedCategoryId;
                next = new SpecifyPhoneStep(ChatId, client, Data);
            }

            await next.Execute(update, client);
            NextStep = next.NextStep;
        }

        public ReturnOrOrderStep(OrderData data, string categoryID, long chatId, IBotClient client) : base(chatId, client)
        {
            SelectedCategoryId = categoryID;
            Data = data;
        }
    }
}
