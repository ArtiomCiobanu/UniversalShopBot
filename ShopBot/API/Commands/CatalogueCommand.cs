using ShopBot.API.Commands.Steps;
using ShopBot.API.Commands.Steps.CatalogueSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands
{
    public class CatalogueCommand : MultiStepCommand
    {
        public override string Name => "catalogue";
        public override IStep GetInitialStep(Message message, TelegramBotClient client) => new InitialCatalogueStep(message, client);

        public CatalogueCommand(List<IStep> stepPool) : base(stepPool)
        { }
    }
}
