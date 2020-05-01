using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Singletones
{
    public static class Catalogue
    {
        public static Category[] Categories => new Category[]
        {
            new Category("Категория 1", "1"),
            new Category("Категория 2", "2"),
            new Category("Категория 3", "3")
        };
        public static Product[] Products => new Product[]
        {
            new Product("1", "1", "Товар 1"),
            new Product("2", "1", "Товар 2"),
            new Product("3", "1", "Товар 3"),
            new Product("4", "2", "Товар 4"),
            new Product("5", "2", "Товар 5"),
            new Product("6", "2", "Товар 6"),
            new Product("7", "3", "Товар 7"),
            new Product("8", "3", "Товар 8"),
            new Product("9", "3", "Товар 9"),
        };

        public static string GetCategoryName(string id)
        {
            return Categories.SingleOrDefault(c => c.Id == id).Name;
        }
        public static string GetCategoryNameByProductId(string productId)
        {
            var categoryID = Products.SingleOrDefault(p => p.Id == productId).CategoryId;

            return Categories.SingleOrDefault(c => c.Id == categoryID).Name;
        }
        public static string GetCategoryId(string name)
        {
            return Categories.SingleOrDefault(c => c.Name == name).Id;
        }
        public static string GetProductName(string id)
        {
            return Products.SingleOrDefault(p => p.Id == id).Name;
        }
    }
}
