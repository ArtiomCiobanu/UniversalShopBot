using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class InitialCatalogueStep : CatalogueStep
    {
        public override string Message => "Каталог наших товаров:\nВыберите категорию:";

        private KeyboardMarkup KeyboardMarkup { get; }

        private async Task BackAction(BotUpdate update, IBotClient client)
        {
            await EditMessageAsync(Message, update.CallbackMessageId, KeyboardMarkup);
        }
        public override async Task DefaultAction(BotUpdate update, IBotClient client)
        {
            await SendMessageAsync(Message, keyboardMarkup: KeyboardMarkup);
        }

        public InitialCatalogueStep(long chatId, IBotClient client) : base(chatId, client)
        {
            CallbackActions.Add("Back", BackAction);

            KeyboardMarkup = new KeyboardMarkup(KeyboardTools.GetCategoriesButtonRow(CommandName));
            NextStep = new ShowCatalogueProductsStep(ChatId, BotClient);
        }
    }
}
