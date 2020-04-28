using Shop.API.Models;
using Shop.API.Singletones;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyOrderGoodsStep : OrderStep
    {
        public override string Message => "Теперь выберите товар:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;
            var callbackMessage = callback.Message;
            var selectedItem = int.Parse(callback.Data) - 1;

            Data.Category = Catalogue.Categories.FirstOrDefault(x => x.Value == callback.Data).Key;
            NextStep = new SpecifyPhoneStep(ChatId, BotClient, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetProductsButtonRow(Data.Category));

            await EditMessageAsync($"Вы выбрали Категорию {callback.Data}\n{Message}", callback, keyboard);
        }
        public SpecifyOrderGoodsStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
