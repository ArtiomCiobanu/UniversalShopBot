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
        public string CategoryId { get; private set; }

        private string SelectedCategoryName { get; set; }

        public override async Task MainAction(BotUpdate update, IBotClient client)
        {
            var keyboard = new KeyboardMarkup(new KeyboardButtonInfo[][]
            {
                KeyboardTools.GetProductsButtonRow(SelectedCategoryName,CommandName),
                new KeyboardButtonInfo[]{ KeyboardTools.GetBackButton(CommandName) }
            });

            NextStep = new DescribeProductStep(ChatId, client, SelectedCategoryName);

            await EditMessageAsync(string.Format(Message, SelectedCategoryName), update.CallbackMessageId, keyboard);
        }
        private Task BackAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                SelectedCategoryName = Catalog.GetCategoryNameByProductId(CategoryId);
            });
        }

        public override Task DefaultAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                SelectedCategoryName = Catalog.GetCategoryName(update.CallbackData);
            });
        }

        public ShowCatalogueProductsStep(long chatId, IBotClient client) : base(chatId, client)
        {
            CallbackActions.Add("Back", BackAction);
        }
        public ShowCatalogueProductsStep(string categoryId, long chatId, IBotClient client) : base(chatId, client)
        {
            CallbackActions.Add("Back", BackAction);

            CategoryId = categoryId;
        }
    }
}
