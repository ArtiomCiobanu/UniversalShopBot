using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
{
    public class OrderData
    {
        public string FullName { get; }
        public string Email { get; set; }
        public string Phone { get; set; }

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
