using Shop.API.Commands.Steps.OrderSteps;
using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class ReturnOrOrderStep : CatalogueStep
    {
        public override string Message => null;
        public string SelectedCategoryId { get; }
        public OrderData Data { get; private set; }

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;
            IStep next = null;
            if (callback.Data == "Back")
            {
                next = new ShowCatalogueProductsStep(SelectedCategoryId, ChatId, client);
            }
            else if (callback.Data == "Order")
            {
                Data.SetFullName(callback.Message);
                callback.Data = SelectedCategoryId;
                next = new SpecifyPhoneStep(ChatId, client, Data);
            }

            await next.Execute(update, client);
            NextStep = next.NextStep;
        }

        public ReturnOrOrderStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
        public ReturnOrOrderStep(string categoryId, long chatId, TelegramBotClient client) : base(chatId, client)
        {
            SelectedCategoryId = categoryId;
        }
        public ReturnOrOrderStep(OrderData data, string categoryID, long chatId, TelegramBotClient client) : base(chatId, client)
        {
            SelectedCategoryId = categoryID;
            Data = data;
        }
    }
}
