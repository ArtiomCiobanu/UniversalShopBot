using Shop.API.Singletones;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class InitialCatalogueStep : Step
    {
        public override string Message => "Каталог наших товаров:\nВыберите категорию:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetCategoriesButtonRow());

            NextStep = new ShowCatalogueProductsStep(ChatId, BotClient);

            if (callback != null && callback.Data == "Back")
            {
                await EditMessageAsync(Message, callback, keyboard);
            }
            else
            {
                await SendMessageAsync(Message, keyboard);
            }
        }

        public InitialCatalogueStep(Message message, TelegramBotClient client) : base(message, client)
        {
        }
        public InitialCatalogueStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
    }
}
