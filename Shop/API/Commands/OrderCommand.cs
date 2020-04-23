using Shop.API.Commands.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public class OrderCommand : MultiStepCommand
    {
        public override string Name => "order";
        public override IStep GetInitialStep(Message message) => new InitialOrderStep(message);
    }
}
