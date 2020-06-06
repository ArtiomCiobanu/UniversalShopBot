using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class KeyboardMarkup
    {
        public KeyboardButtonInfo[][] KeyboardButtons { get; private set; }

        public KeyboardMarkup(KeyboardButtonInfo keyboardButton)
        {
            KeyboardButtons = new KeyboardButtonInfo[1][]
            {
               new KeyboardButtonInfo[] { keyboardButton }
            };
        }
        public KeyboardMarkup(KeyboardButtonInfo[] keyboardRow)
        {
            KeyboardButtons = new KeyboardButtonInfo[1][]
            {
                keyboardRow
            };
        }
        public KeyboardMarkup(KeyboardButtonInfo[][] keyboardMarkup)
        {
            KeyboardButtons = keyboardMarkup;
        }
    }
}
