using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class ConfirmOrderStep : OrderStep
    {
        public override string Message => "Всё правильно? Тогда можете подтвердить оформление заказа:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;

            Data.Adress = message.Text;

            NextStep = new FinishOrderStep(ChatId, Data);

            var keyboard = new InlineKeyboardMarkup(new InlineKeyboardButton()
            {
                Text = "Подтвердить и оформить заказ",
                CallbackData = "Confirmed"
            });

            await client.SendTextMessageAsync(ChatId,
                $"Итого:\n" +
                $"Вас зовут: {Data.FullName}\n" +
                $"Ваш заказ: {Data.Category} - {Data.Product}\n" +
                $"Телефон: {Data.PhoneNumber}\n" +
                $"Адрес: {Data.Adress}\n" +
                $"{Message}",
                replyMarkup: keyboard);
        }

        public ConfirmOrderStep(long chatId, OrderData data) : base(chatId, data)
        {

        }
    }
}
