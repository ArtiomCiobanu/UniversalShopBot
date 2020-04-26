using Shop.API.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public abstract class OrderStep : IStep
    {
        public OrderData Data { get; }
        public long ChatId { get; }
        public string Message { get; }
        public IStep NextStep { get; set; } = null;

        public abstract Task Execute(Update update, TelegramBotClient client);

        public OrderStep(Message message)
        {
            ChatId = message.Chat.Id;
            Data = new OrderData(message.Chat.FirstName, message.Chat.LastName);
        }
        public OrderStep(Message message, OrderData data)
        {
            ChatId = message.Chat.Id;
            Data = data;
        }
        public OrderStep(long chatId, OrderData data)
        {
            Data = data;
            ChatId = chatId;
        }
    }
}
