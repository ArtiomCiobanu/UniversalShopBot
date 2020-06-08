using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class FinishOrderStep : OrderStep
    {
        public override string Message => "Заказ оформлен! Наш курьер скоро с вами свяжется.";
        public string CancellationMessage => "Вы отменили заказ.\nМожете оформить заново командой /order";

        public override async Task Execute(BotUpdate update, IBotClient client)
        {
            string command = update.CallbackData.Split()[1];
            if (command == "Confirmed")
            {
                await EditMessageAsync(Message, update.CallbackMessageId);
            }
            else if (command == "Cancelled")
            {
                await EditMessageAsync(CancellationMessage, update.CallbackMessageId);
            }
        }

        public FinishOrderStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}
