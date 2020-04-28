using Shop.API.Singletones;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class InitialCatalogueStep : Step
    {
        public override string Message => "Каталог наших товаров:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetCategoriesButtonRow());

            await SendMessageAsync(Message, keyboard);
        }

        public InitialCatalogueStep(Message message, TelegramBotClient client) : base(message, client)
        {
        }
    }
}
