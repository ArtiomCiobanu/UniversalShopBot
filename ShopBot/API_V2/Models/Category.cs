using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Category()
        {

        }
        public Category(string name, string id)
        {
            Id = id;
            Name = name;
        }
    }
}
