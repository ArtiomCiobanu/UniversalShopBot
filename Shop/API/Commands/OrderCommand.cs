using Shop.API.Commands.Steps;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class OrderCommand : MultiStepCommand
    {
        public override string Name => "order";
        public override IStep GetInitialStep(Message message, TelegramBotClient client) => new InitialOrderStep(message, client);

        public OrderCommand(List<IStep> stepPool) : base(stepPool)
        { }
    }
}
