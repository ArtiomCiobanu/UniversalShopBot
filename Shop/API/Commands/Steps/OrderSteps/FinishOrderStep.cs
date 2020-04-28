using Shop.API.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class FinishOrderStep : OrderStep
    {
        public override string Message => "Наш курьер скоро с вами свяжется.";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            if (update.CallbackQuery.Data == "Confirmed")
            {
                await EditMessageAsync($"Заказ оформлен!\n" +
                    $"Вас зовут: {Data.FullName}\n" +
                    $"Ваш заказ: {Data.Category} - {Data.Product}\n" +
                    $"Телефон: {Data.PhoneNumber}\n" +
                    $"Адрес: {Data.Adress}\n" +
                    $"{Message}",
                    callback, null);
            }
            else
            {
                await EditMessageAsync("Оформите заказ заново.", callback, null);
            }
        }

        public FinishOrderStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}

