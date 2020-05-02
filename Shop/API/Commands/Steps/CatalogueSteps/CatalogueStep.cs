using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public abstract class CatalogueStep : Step
    {
        public override string CommandName => "catalogue";
        public CatalogueStep(Message message, TelegramBotClient client) : base(message, client)
        {
        }
        public CatalogueStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
    }
}
