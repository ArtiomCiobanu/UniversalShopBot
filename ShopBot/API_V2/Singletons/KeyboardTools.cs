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
    }
}
