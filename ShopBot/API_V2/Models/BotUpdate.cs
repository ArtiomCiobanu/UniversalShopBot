using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class BotUpdate
    {
        public long ChatId { get; set; }
        public BotMessage Message { get; set; }
        public BotCallback Callback { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public DateTime Date { get; set; }
        public DateTime? EditDate { get; set; }

        public BotUpdate()
        {
            Message = new BotMessage();
            Callback = new BotCallback();
        }
    }
}
