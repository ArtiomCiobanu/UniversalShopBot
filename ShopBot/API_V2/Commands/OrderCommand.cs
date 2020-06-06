using ShopBot.API_V2.Commands.Steps;
using ShopBot.API_V2.Commands.Steps.Order;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public class OrderCommand : MultiStepCommand
    {
        public override string Name => "order";

        public override IStep GetInitialStep(BotUpdate update, IBotClient client) => new InitialOrderStep(update, client);

        public OrderCommand(List<IStep> stepPool) : base(stepPool)
        {
        }
    }
}
