using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Singletons
{
    public static class KeyboardTools
    {
        public static KeyboardButtonInfo[] GetCategoriesButtonRow(string commandName)
        {
            return Catalog.Categories.Select(c => new KeyboardButtonInfo(c.Name, c.Id)).ToArray();
        }
        public static KeyboardButtonInfo[] GetProductsButtonRow(string categoryName, string commandName)
        {
            var categoryId = Catalog.Categories.SingleOrDefault(c => c.Name == categoryName).Id;

            return Catalog.Products.Where(p => p.CategoryId == categoryId).Select(p => new KeyboardButtonInfo(p.Name, p.Id)).ToArray();
        }
        public static KeyboardButtonInfo[][] GetConfirmAndCancelButtons(string commandName)
        {
            return new KeyboardButtonInfo[][]
            {
               new KeyboardButtonInfo[]{ GetConfirmationButton(commandName) },
               new KeyboardButtonInfo[]{ GetCancellationButton(commandName) }
            };
        }
        public static KeyboardButtonInfo[][] GetOrderAndBackButtons(string product, string commandName)
        {
            return new KeyboardButtonInfo[][]
            {
                new KeyboardButtonInfo[]{ GetOrderButton(product,commandName) },
                new KeyboardButtonInfo[]{ GetBackButton(commandName)}
            };
        }

        public static KeyboardButtonInfo GetConfirmationButton(string commandName)
        {
            return new KeyboardButtonInfo("Подтвердить и оформить заказ", $"{commandName} Confirmed");
        }
        public static KeyboardButtonInfo GetCancellationButton(string commandName)
        {
            return new KeyboardButtonInfo("Отмена", $"{commandName} Cancelled");
        }
        public static KeyboardButtonInfo GetBackButton(string commandName)
        {
            return new KeyboardButtonInfo("« Вернуться назад", $"{commandName} Back");
        }
        public static KeyboardButtonInfo GetOrderButton(string product, string commandName)
        {
            return new KeyboardButtonInfo("Заказать", $"{commandName} Order");
        }
    }
}

