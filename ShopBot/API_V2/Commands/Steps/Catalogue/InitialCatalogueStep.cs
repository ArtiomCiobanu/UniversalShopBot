using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class InitialCatalogueStep : CatalogueStep
    {
        public override string Message => "Каталог наших товаров:\nВыберите категорию:";

        public override async Task Execute(BotUpdate update, IBotClient client)
        {
            var keyboard = new KeyboardMarkup(KeyboardTools.GetCategoriesButtonRow(CommandName));
            NextStep = new ShowCatalogueProductsStep(ChatId, BotClient);

            if (update.CallbackData == "Back")
            {
                await EditMessageAsync(Message, update.CallbackMessageId, keyboard);
            }
            else
            {
                await SendMessageAsync(Message, keyboardMarkup: keyboard);
            }
        }

        public InitialCatalogueStep(long chatId, IBotClient client) : base(chatId, client)
        {

        }
    }
}
