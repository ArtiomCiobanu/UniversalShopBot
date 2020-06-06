using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class KeyboardButtonInfo
    {
        public string Text { get; set; }
        public string CallbackData { get; set; }

        public KeyboardButtonInfo(string text, string callbackData)
        {
            Text = text;
            CallbackData = callbackData;
        }
    }
}
