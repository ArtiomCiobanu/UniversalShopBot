using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyOrderGoodsStep : IOrderStep
    {
        public long ChatId { get; }
        public string Message => "Теперь введите свой номер телефона";
        public IStep NextStep => null;
        public OrderData Data { get; }

        public async Task Execute(TelegramBotClient client)
        {
            await client.SendTextMessageAsync(ChatId, "Теперь введите ваше имя");
        }
        public SpecifyOrderGoodsStep(long chatId, OrderData data)
        {
            ChatId = chatId;
            Data = data;
        }
    }
}
