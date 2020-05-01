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

        public static InlineKeyboardButton[] GetKeyboardButtonAsArray()
        {
            return new InlineKeyboardButton[]
            {
                GetBackButton()
            };
        }
        public static InlineKeyboardButton GetBackButton()
        {
            return new InlineKeyboardButton()
            {
                Text = "« Вернуться назад",
                CallbackData = "Back"
            };
        }

        public static InlineKeyboardButton[] GetCategoriesButtonRow()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            Catalogue.Categories.ToList().ForEach(c => d.Add(c.Name, c.Id));

            return GetKeyboardButtonRow(d);
        }
        public static InlineKeyboardButton[] GetProductsButtonRow(string categoryName)
        {
            var categoryId = Catalogue.Categories.SingleOrDefault(c => c.Name == categoryName).Id;

            Dictionary<string, string> d = new Dictionary<string, string>();
            Catalogue.Products.Where(c => c.CategoryId == categoryId).ToList().ForEach(c => d.Add(c.Name, c.Id));

            return GetKeyboardButtonRow(d);
        }
    }
}
