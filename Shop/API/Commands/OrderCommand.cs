using Shop.API.Commands.Steps;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class OrderCommand : MultiStepCommand
    {
        public override string Name => "order";
        public override IStep GetInitialStep(Message message, TelegramBotClient client) => new InitialOrderStep(message, client);
    }
}
