using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class SpecifyPhoneStep : OrderStep
    {
        public override string Message => $"Вы выбрали:\n{Data.ProductName} - {Data.CategoryName}\nТеперь введите свой номер телефона:";

        public override async Task MainAction(BotUpdate update, IBotClient clien)
        {
            if (string.IsNullOrEmpty(Data.ProductId))
            {
                Data.ProductId = update.Callback.SerializedData.Data;
            }
            NextStep = new SpecifyAdressStep(ChatId, BotClient, Data);

            await EditMessageAsync(Message, update.Callback.MessageId);
        }

        public SpecifyPhoneStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
