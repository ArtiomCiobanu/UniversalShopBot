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

        public override async Task Execute(BotUpdate update, IBotClient client)
        {

            var selectedCategoryName = (update.CallbackData == "Back") ?
                Catalog.GetCategoryNameByProductId(CategoryId) : Catalog.GetCategoryName(update.CallbackData);

            /*var keyboard = new InlineKeyboardButton[][]
            {
                ReplyKeyboardTools.GetProductsButtonRow(selectedCategoryName,CommandName),
                ReplyKeyboardTools.GetBackButton(CommandName).ToArray()
            };*/
            var keyboard = new KeyboardMarkup(new KeyboardButtonInfo[][]
            {
                KeyboardTools.GetProductsButtonRow(selectedCategoryName,CommandName),
                new KeyboardButtonInfo[]{ KeyboardTools.GetBackButton(CommandName) }
            });

            NextStep = null; //new DescribeProductStep(ChatId, client, selectedCategoryName);

            await EditMessageAsync(string.Format(Message, selectedCategoryName), update.CallbackMessageId, keyboard);
        }

        public ShowCatalogueProductsStep(long chatId, IBotClient client) : base(chatId, client)
        {

        }
    }
}
