using Shop.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.CatalogueSteps
{
    public class ShowCatalogueProductsStep : Step
    {
        public override string Message => "Каталог наших товаров:\nВсе товары в {0}:";
        public string Category { get; private set; }

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;

            string selectedCategory = "";
            if (callback != null && callback.Data == "Back")
            {
                selectedCategory = Catalogue.GetCategoryKeyByProductValue(Category);
            }
            else
            {
                selectedCategory = Catalogue.GetCategoryKey(callback.Data);
            }

            var keyboard = new InlineKeyboardButton[][]
            {
                ReplyKeyboardTools.GetProductsButtonRow(selectedCategory),
                ReplyKeyboardTools.GetKeyboardButtonAsArray()
            };

            NextStep = new DescribeProductStep(ChatId, client);

            await EditMessageAsync(string.Format(Message, selectedCategory), callback, keyboard);
        }

        public ShowCatalogueProductsStep(long chatId, TelegramBotClient client) : base(chatId, client)
        {
        }
        public ShowCatalogueProductsStep(string category, long chatId, TelegramBotClient client) : base(chatId, client)
        {
            Category = category;
        }
    }
}
