using ShopBot.API.Commands.Steps.OrderSteps;
using ShopBot.API.Models;
using ShopBot.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands.Steps.CatalogueSteps
{
    public class DescribeProductStep : CatalogueStep
    {
        public override string Message => "Это описание невероятного";
        public OrderData Data { get; private set; } = new OrderData();

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            if (callback != null && callback.Data == "Back")
            {
                var next = new InitialCatalogueStep(ChatId, client);
                await next.Execute(update, client);
                NextStep = next.NextStep;
            }
            else
            {
                Data.Product = Catalogue.GetProductName(callback.Data);
                var backButton = ReplyKeyboardTools.GetOrderAndBackButtons(Data.Product, CommandName);

                NextStep = new ReturnOrOrderStep(Data, callback.Data, ChatId, client);

                await EditMessageAsync($"{Message} {Data.Product}", callback, backButton);
            }
        }

        public DescribeProductStep(long chatId, TelegramBotClient client, string selectedCategory) :
            base(chatId, client)
        {
            Data.Category = selectedCategory;
        }
    }
}
