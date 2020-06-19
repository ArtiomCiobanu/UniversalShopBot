using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class SpecifyAdressStep : OrderStep
    {
        public override string Message =>
            $"Вы выбрали:\n" +
            $"{Data.Category} - {Data.Product}\n" +
            $"Ваш телефон: {Data.PhoneNumber}\n" +
            "Теперь введите свой адрес:";

        public override async Task MainAction(BotUpdate update, IBotClient clien)
        {
            Data.PhoneNumber = update.MessageText;
            NextStep = new ConfirmOrderStep(ChatId, BotClient, Data);

            await SendMessageAsync(Message);
        }

        public SpecifyAdressStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}
