using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var callbackMessage = update.CallbackQuery.Message;

            if (update.CallbackQuery.Data == "Confirmed")
            {
                await client.EditMessageTextAsync(callbackMessage.Chat.Id, callbackMessage.MessageId,
                    $"Заказ оформлен!\n" +
                    $"Вас зовут: {Data.FullName}\n" +
                    $"Ваш заказ: {Data.Category} - {Data.Product}\n" +
                    $"Телефон: {Data.PhoneNumber}\n" +
                    $"Адрес: {Data.Adress}\n" +
                    $"{Message}",
                    replyMarkup: null);
            }
            else
            {
                await client.EditMessageTextAsync(callbackMessage.Chat.Id, callbackMessage.MessageId,
                    "Оформите заказ заново.", replyMarkup: null);
            }
        }

        public FinishOrderStep(long chatId, OrderData data) : base(chatId, data)
        {

        }
    }
}

