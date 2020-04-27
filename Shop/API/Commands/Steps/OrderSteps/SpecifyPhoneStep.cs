using Shop.API.Models;
using Shop.API.Singletones;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyPhoneStep : OrderStep
    {
        public override string Message => "Теперь введите свой номер телефона:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;
            var callbackMessage = callback.Message;
            var selectedProduct = callback.Data;
            var category = Data.Category;

            Data.Product = Catalogue.Products[category].FirstOrDefault(x => x.Value == selectedProduct).Key;

            NextStep = new SpecifyAdressStep(ChatId, Data);

            await client.EditMessageTextAsync(ChatId, callbackMessage.MessageId,
                $"Вы выбрали:\n{Data.Product} - {category}\n{Message}", replyMarkup: null);
        }

        public SpecifyPhoneStep(long chatId, OrderData data) : base(chatId, data)
        {
        }
    }
}
