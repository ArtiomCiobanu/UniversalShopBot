using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class ReturnFromProductDescriptionStep : CatalogueStep
    {
        public override string Message => null;
        public string Category { get; }

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;
            if (callback.Data == "Back")
            {
                var previous = new ShowCatalogueProductsStep(Category, ChatId, client);
                await previous.Execute(update, client);
                NextStep = previous.NextStep;
            }
        }

        public ReturnFromProductDescriptionStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
        public ReturnFromProductDescriptionStep(string category, long chatId, TelegramBotClient client) : base(chatId, client)
        {
            Category = category;
        }
    }
}
