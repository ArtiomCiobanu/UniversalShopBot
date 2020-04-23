using Shop.API.Commands.Steps.OrderSteps;
using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps
{
    public class InitialOrderStep : IOrderStep
    {
        public long ChatId { get; }
        public string Message => "Отлично! Выберите категорию: 1, 2 или 3.";
        public IStep NextStep { get; set; } = null;
        public OrderData Data { get; }

        public async Task Execute(TelegramBotClient client)
        {
            NextStep = new SpecifyOrderGoodsStep(ChatId, Data);

            await client.SendTextMessageAsync(ChatId, Message);
        }

        public InitialOrderStep(Message message)
        {
            ChatId = message.Chat.Id;
            Data = new OrderData(message.Chat.FirstName, message.Chat.LastName);
        }
    }
}
