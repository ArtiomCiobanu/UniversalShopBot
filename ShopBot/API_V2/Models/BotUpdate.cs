using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class BotUpdate
    {
        public long ChatId { get; set; }

        //Заменить на BotMessageData
        public string MessageText { get; set; }
        public int MessageId { get; set; }

        //Заменить на BotCallbackData
        public string CallbackData { get; set; }
        public int CallbackMessageId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public DateTime Date { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
