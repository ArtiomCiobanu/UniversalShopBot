using Shop.API.Models;
using Shop.API.Singletones;
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
        public override string Message =>
                 $"Итого:\n" +
                 $"Вас зовут: {Data.FullName}\n" +
                 $"Ваш заказ: {Data.Category} - {Data.Product}\n" +
                 $"Телефон: {Data.PhoneNumber}\n" +
                 $"Адрес: {Data.Adress}\n";
        public string IsItCorrectMessage => "Всё правильно? Тогда можете подтвердить оформление заказа:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            Data.Adress = update.Message.Text;

            NextStep = new FinishOrderStep(ChatId, BotClient, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetConfirmAndCancelButtons());

            await SendMessageAsync(Message);
            await SendMessageAsync(IsItCorrectMessage, keyboard);
        }

        public ConfirmOrderStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {

        }
    }
}
