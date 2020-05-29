using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ShopBot.API.Models
{
    public class OrderData
    {
        public string FullName { get; private set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public void SetFullName(string fullName)
        {
            FullName = fullName;
        }
        public void SetFullName(string firstName, string lastName)
        {
            FullName = $"{firstName} {lastName}";
        }
        public void SetFullName(Message message)
        {
            FullName = $"{message.Chat.FirstName} {message.Chat.LastName}";
        }

        public OrderData()
        {

        }
        public OrderData(string fullName)
        {
            FullName = fullName;
        }
        public OrderData(string firstName, string lastName)
        {
            SetFullName(firstName, lastName);
        }
        public OrderData(Message message)
        {
            SetFullName(message);
        }
    }
}
