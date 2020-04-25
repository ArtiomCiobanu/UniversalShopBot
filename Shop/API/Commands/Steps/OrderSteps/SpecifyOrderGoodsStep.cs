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
    public class SpecifyOrderGoodsStep : IOrderStep
    {
        public long ChatId { get; }
        public string Message => "Теперь выберите товар:";
        public IStep NextStep { get; set; } = null;
        public OrderData Data { get; }

        Dictionary<string, string>[] buttons =
        {
            new Dictionary<string, string>()
            {
                {"Товар 1", "1" },
                {"Товар 2", "2" },
                {"Товар 3", "3" }
            },
            new Dictionary<string, string>()
            {
                {"Товар 4", "4" },
                {"Товар 5", "5" },
                {"Товар 6", "6" }
            },
            new Dictionary<string, string>()
            {
                {"Товар 7", "7" },
                {"Товар 8", "8" },
                {"Товар 9", "9" }
            }
        };

        public async Task Execute(Update update, TelegramBotClient client)
        {
            NextStep = new SpecifyPhoneStep();

            var callback = update.CallbackQuery;
            var callbackMessage = callback.Message;
            var selectedItem = int.Parse(callback.Data) - 1;

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetKeyboardButtonRow(buttons[selectedItem]));

            await client.EditMessageTextAsync(callbackMessage.Chat.Id, callbackMessage.MessageId,
                $"Вы выбрали Категорию {update.CallbackQuery.Data}. {Message}", replyMarkup: keyboard);
        }
        public SpecifyOrderGoodsStep(long chatId, OrderData data)
        {
            ChatId = chatId;
            Data = data;
        }
    }
}
