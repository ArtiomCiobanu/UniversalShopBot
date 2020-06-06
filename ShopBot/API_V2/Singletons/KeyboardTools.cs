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
            return Catalogue.Categories.Select(c => new KeyboardButtonInfo(c.Name, c.Id)).ToArray();
        }
        public static KeyboardButtonInfo[] GetProductsButtonRow(string categoryName, string commandName)
        {
            var categoryId = Catalogue.Categories.SingleOrDefault(c => c.Name == categoryName).Id;

            return Catalogue.Products.Where(p => p.CategoryId == categoryId).Select(p => new KeyboardButtonInfo(p.Name, p.Id)).ToArray();
        }
    }
}
