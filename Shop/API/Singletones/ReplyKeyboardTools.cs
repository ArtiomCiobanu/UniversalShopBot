using System.Collections.Generic;
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
            return GetKeyboardButtonRow(Catalogue.Categories);
        }
        public static InlineKeyboardButton[] GetProductsButtonRow(string category)
        {
            return GetKeyboardButtonRow(Catalogue.Products[category]);
        }
    }
}
