using Shop.API.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public abstract class OrderStep : Step
    {
        public OrderData Data { get; }

        public OrderStep(Message message) : base(message.Chat.Id)
        {
            Data = new OrderData(message.Chat.FirstName, message.Chat.LastName);
        }
        public OrderStep(Message message, TelegramBotClient client) : base(message.Chat.Id, client)
        {
            Data = new OrderData(message.Chat.FirstName, message.Chat.LastName);
        }
        public OrderStep(Message message, OrderData data) : base(message.Chat.Id)
        {
            Data = data;
        }
        public OrderStep(long chatId, OrderData data) : base(chatId)
        {
            Data = data;
        }
        public OrderStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client)
        {
            Data = data;
        }
    }
}
