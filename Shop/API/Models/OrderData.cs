using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
{
    public class OrderData
    {
        public string FullName { get; }
        public string Category { get; set; }
        public string Product { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public OrderData(string fullName)
        {
            FullName = fullName;
        }
        public OrderData(string firstName, string lastName)
        {
            FullName = $"{firstName} {lastName}";
        }
    }
}
