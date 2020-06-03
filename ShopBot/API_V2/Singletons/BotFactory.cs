using ShopBot.API_V2;
using ShopBot.API_V2.Commands;
using ShopBot.API_V2.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Singletons
{
    public static class BotFactory
    {
        public static Dictionary<string, IBot> BotDictionary = new Dictionary<string, IBot>();

        /// <summary>
        /// Adds a bot to the dictionary with it's name as a key
        /// </summary>
        /// <param name="bot"></param>
        public static void AddBot(IBot bot)
        {
            BotDictionary.Add(bot.Name, bot);
        }
    }
}
