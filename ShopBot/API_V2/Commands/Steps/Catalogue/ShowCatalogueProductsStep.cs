using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBot.API_V2.Singletones;
using ShopBot.API_V2.Singletons;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class ShowCatalogueProductsStep : CatalogueStep
    {
        public override string Message => "Каталог наших товаров:\nВсе товары в {0}:";

        public override async Task MainAction(BotUpdate update, IBotClient client)
        {
            if (string.IsNullOrEmpty(Data.CategoryId))
            {
                Data.CategoryId = update.Callback.SerializedData.Data;
            }

            var keyboard = new KeyboardMarkup(new KeyboardButtonInfo[][]
            {
                KeyboardTools.GetProductsButtonRow(Data.CategoryName, CommandName),
                new KeyboardButtonInfo[]{ KeyboardTools.GetBackButton(CommandName) }
            });

            NextStep = new DescribeCatalogueProductStep(ChatId, client, Data);

            await EditMessageAsync(string.Format(Message, Data.CategoryName), update.Callback.MessageId, keyboard);
        }

        public override Task DefaultAction(BotUpdate update, IBotClient client) => Task.Run(() =>
        {
            Data.CategoryId = update.Callback.SerializedData.Data;
        });

        public ShowCatalogueProductsStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
