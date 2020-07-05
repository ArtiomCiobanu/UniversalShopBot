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

        private async Task ConfirmedAction(BotUpdate update, IBotClient client)
        {
            await EditMessageAsync(Message, update.Callback.MessageId);
        }
        private async Task CancelledAction(BotUpdate update, IBotClient client)
        {
            await EditMessageAsync(CancellationMessage, update.Callback.MessageId);
        }

        public FinishOrderStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {
            CallbackActions.Add("Confirmed", ConfirmedAction);
            CallbackActions.Add("Cancelled", CancelledAction);
        }
    }
}
