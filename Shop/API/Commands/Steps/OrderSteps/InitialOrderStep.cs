using Shop.API.Commands.Steps.OrderSteps;
using Shop.API.Models;
using Shop.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps
{
    public class InitialOrderStep : IOrderStep
    {
        public long ChatId { get; }
        public string Message => "Отлично! Выберите категорию:";
        public IStep NextStep { get; set; } = null;
        public OrderData Data { get; }

        Dictionary<string, string> buttons = new Dictionary<string, string>()
        {
            {"Категория 1", "1" },
            {"Категория 2", "2" },
            {"Категория 3", "3" }
        };

        public async Task Execute(Update update, TelegramBotClient client)
        {
            NextStep = new SpecifyOrderGoodsStep(ChatId, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetKeyboardButtonRow(buttons));

            await client.SendTextMessageAsync(ChatId, Message, replyMarkup: keyboard);
        }

        public InitialOrderStep(Message message)
        {
            ChatId = message.Chat.Id;
            Data = new OrderData(message.Chat.FirstName, message.Chat.LastName);
        }
    }
}
