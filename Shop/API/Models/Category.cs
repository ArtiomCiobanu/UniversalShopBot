using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
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
