using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
{
    public class Product
    {
        public string Category { get; }
        public string Name { get; }

        public Product(string category, string name)
        {
            Category = category;
            Name = name;
        }
    }
}
