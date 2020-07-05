using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class BotMessage
    {
        public string Text { get; set; }
        public int MessageId { get; set; }

        public BotMessage()
        {

        }
    }
}
