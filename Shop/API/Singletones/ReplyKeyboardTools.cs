using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Singletones
{
    public static class ReplyKeyboardTools
    {
        public static InlineKeyboardButton[] GetKeyboardButtonRow(Dictionary<string, string> items)
        {
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();

            foreach (var i in items)
            {
                buttons.Add(new InlineKeyboardButton()
                {
                    Text = i.Key,
                    CallbackData = i.Value
                });
            }

            return buttons.ToArray();
        }

        public static InlineKeyboardButton[][] GetConfirmAndCancelButtons(string commandName)
        {
            return new InlineKeyboardButton[][]
            {
                GetConfirmationButton(commandName).ToArray(),
                GetCancellationButton(commandName).ToArray()
            };
        }
        public static InlineKeyboardButton GetConfirmationButton(string commandName)
        {
            return new InlineKeyboardButton()
            {
                Text = "Подтвердить и оформить заказ",
                CallbackData = $"{commandName} Confirmed"
            };
        }
        public static InlineKeyboardButton GetCancellationButton(string commandName)
        {
            return new InlineKeyboardButton()
            {
                Text = "Отмена",
                CallbackData = $"{commandName} Cancelled"
            };
        }
        public static InlineKeyboardButton GetBackButton(string commandName)
        {
            return new InlineKeyboardButton()
            {
                Text = "« Вернуться назад",
                CallbackData = $"{commandName} Back"
            };
        }

        public static InlineKeyboardButton[] GetCategoriesButtonRow(string commandName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            Catalogue.Categories.ToList().ForEach(c => d.Add(c.Name, $"{commandName} {c.Id}"));

            return GetKeyboardButtonRow(d);
        }
        public static InlineKeyboardButton[] GetProductsButtonRow(string categoryName, string commandName)
        {
            var categoryId = Catalogue.Categories.SingleOrDefault(c => c.Name == categoryName).Id;

            Dictionary<string, string> d = new Dictionary<string, string>();
            Catalogue.Products.Where(c => c.CategoryId == categoryId).ToList().
                ForEach(c => d.Add(c.Name, $"{commandName} {c.Id}"));

            return GetKeyboardButtonRow(d);
        }

        public static InlineKeyboardButton[] ToArray(this InlineKeyboardButton inlineKeyboardButton)
        {
            return new[]
            {
                inlineKeyboardButton
            };
        }
    }
}
