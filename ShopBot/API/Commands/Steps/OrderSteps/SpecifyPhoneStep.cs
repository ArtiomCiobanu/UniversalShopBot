using ShopBot.API.Models;
using ShopBot.API.Singletones;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands.Steps.OrderSteps
{
    public class SpecifyPhoneStep : OrderStep
    {
        public override string Message => $"Вы выбрали:\n{Data.Product} - {Data.Category}\nТеперь введите свой номер телефона:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            Data.Product = Catalogue.GetProductName(callback.Data);
            NextStep = new SpecifyAdressStep(ChatId, BotClient, Data);

            await EditMessageAsync(Message, callback);
        }

        public SpecifyPhoneStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
