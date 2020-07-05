using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public class ConfirmOrderStep : OrderStep
    {
        public override string Message =>
                 $"Итого:\n" +
                 $"Вас зовут: {Data.FullName}\n" +
                 $"Ваш заказ: {Data.CategoryName} - {Data.ProductName}\n" +
                 $"Телефон: {Data.PhoneNumber}\n" +
                 $"Адрес: {Data.Adress}\n";
        public string IsItCorrectMessage => "Всё правильно? Тогда можете подтвердить оформление заказа:";

        public override async Task MainAction(BotUpdate update, IBotClient clien)
        {
            Data.Adress = update.Message.Text;
            NextStep = new FinishOrderStep(ChatId, BotClient, Data);

            var keyboard = new KeyboardMarkup(KeyboardTools.GetConfirmAndCancelButtons(CommandName));

            await SendMessageAsync(Message);
            await SendMessageAsync(IsItCorrectMessage, keyboardMarkup: keyboard);
        }

        public ConfirmOrderStep(long chatId, IBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}
