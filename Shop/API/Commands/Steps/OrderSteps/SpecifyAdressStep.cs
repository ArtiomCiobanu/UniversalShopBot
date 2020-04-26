using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyAdressStep : OrderStep
    {
        public new string Message => "Теперь введите свой адрес:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;

            Data.PhoneNumber = message.Text;

            NextStep = new ConfirmOrderStep(ChatId, Data);

            await client.SendTextMessageAsync(message.Chat.Id,
                $"Вы выбрали:\n" +
                $"{Data.Category} - {Data.Product}\n" +
                $"Ваш телефон: {Data.PhoneNumber}\n" +
                $"{Message}");
        }

        public SpecifyAdressStep(long chatId, OrderData data) : base(chatId, data)
        {
        }
    }
}
