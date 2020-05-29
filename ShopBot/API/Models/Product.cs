using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API.Models
{
    public class Product
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }

        public Product()
        {

        }
        public Product(string id, string categoryId, string name)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
        }
    }
}
