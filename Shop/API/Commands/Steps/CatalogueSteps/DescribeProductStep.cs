using Shop.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class DescribeProductStep : CatalogueStep
    {
        public override string Message => "Это описание невероятного";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            if (callback != null && callback.Data == "Back")
            {
                var initial = new InitialCatalogueStep(ChatId, client);
                await initial.Execute(update, client);
                NextStep = initial.NextStep;
            }
            else
            {
                var product = Catalogue.GetProductName(callback.Data);
                var backButton = ReplyKeyboardTools.GetBackButton();

                NextStep = new ReturnFromProductDescriptionStep(callback.Data, ChatId, client);

                await EditMessageAsync($"{Message} {product}", callback, backButton);
            }
        }

        public DescribeProductStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
    }
}
