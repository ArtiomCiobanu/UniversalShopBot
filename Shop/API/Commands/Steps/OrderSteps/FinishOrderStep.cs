using Shop.API.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class FinishOrderStep : OrderStep
    {
        public override string Message => "Заказ оформлен! Наш курьер скоро с вами свяжется.";
        public string CancellationMessage => "Вы отменили заказ.\nМожете оформить заново командой /order";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            if (callback.Data == "Confirmed")
            {
                await EditMessageAsync(Message, callback);
            }
            else if (callback.Data == "Cancelled")
            {
                await EditMessageAsync(CancellationMessage, callback);
            }
        }

        public FinishOrderStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}

