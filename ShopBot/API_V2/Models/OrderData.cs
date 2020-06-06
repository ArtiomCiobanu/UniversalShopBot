using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
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
    }
}
