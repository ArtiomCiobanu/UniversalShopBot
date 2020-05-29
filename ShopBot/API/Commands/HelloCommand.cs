using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var chatId = update.Message.Chat.Id;
            var messageId = update.Message.MessageId;

            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}
