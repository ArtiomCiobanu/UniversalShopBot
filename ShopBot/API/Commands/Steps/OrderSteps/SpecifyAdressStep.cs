using ShopBot.API.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands.Steps.OrderSteps
{
    public class SpecifyAdressStep : OrderStep
    {
        public override string Message =>
            $"Вы выбрали:\n" +
            $"{Data.Category} - {Data.Product}\n" +
            $"Ваш телефон: {Data.PhoneNumber}\n" +
            "Теперь введите свой адрес:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;

            Data.PhoneNumber = message.Text;
            NextStep = new ConfirmOrderStep(ChatId, BotClient, Data);

            await SendMessageAsync(Message);
        }

        public SpecifyAdressStep(long chatId, TelegramBotClient client, OrderData data) : base(chatId, client, data)
        {
        }
    }
}
