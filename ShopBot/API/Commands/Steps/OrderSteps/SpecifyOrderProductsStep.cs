using ShopBot.API.Models;
using ShopBot.API.Singletones;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ShopBot.API.Commands.Steps.OrderSteps
{
    public class SpecifyOrderProductsStep : OrderStep
    {
        public override string Message => $"Вы выбрали {Data.Category}\nТеперь выберите товар:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            Data.Category = Catalogue.GetCategoryName(callback.Data);
            NextStep = new SpecifyPhoneStep(ChatId, BotClient, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetProductsButtonRow(Data.Category, CommandName));

            await EditMessageAsync(Message, callback, keyboard);
        }
        public SpecifyOrderProductsStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
