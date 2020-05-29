using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var messageId = update.Message.Chat.Id;

            await client.SendTextMessageAsync(messageId,
                "Здравствуйте!\n");
            await client.SendTextMessageAsync(messageId,
                "Используйте следующие команды чтобы:\n" +
                "/help - помощь\n" +
                "/order - оформить заказ\n" +
                "/catalogue - получить каталог товаров\n");
        }
    }
}
