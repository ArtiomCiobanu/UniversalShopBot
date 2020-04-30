using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Singletones
{
    public static class Catalogue
    {
        public static Dictionary<string, string> Categories = new Dictionary<string, string>()
        {
            {"Категория 1", "1" },
            {"Категория 2", "2" },
            {"Категория 3", "3" }
        };

        public static Dictionary<string, Dictionary<string, string>> Products = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "Категория 1",
                new Dictionary<string, string>()
                {
                    {"Товар 1", "1" },
                    {"Товар 2", "2" },
                    {"Товар 3", "3" }
                }
            },
            {
                "Категория 2",
                new Dictionary<string, string>()
                {
                    {"Товар 4", "4" },
                    {"Товар 5", "5" },
                    {"Товар 6", "6" }
                }
            },
            {
                "Категория 3",
                new Dictionary<string, string>()
                {
                    {"Товар 7", "7" },
                    {"Товар 8", "8" },
                    {"Товар 9", "9" }
                }
            }
        };

        public static Product[] products =
        {
            new Product("Категория 1", "Товар 1"),
            new Product("Категория 1", "Товар 2"),
            new Product("Категория 1", "Товар 3"),
            new Product("Категория 2", "Товар 4"),
            new Product("Категория 2", "Товар 5"),
            new Product("Категория 2", "Товар 6"),
            new Product("Категория 3", "Товар 7"),
            new Product("Категория 3", "Товар 8"),
            new Product("Категория 3", "Товар 9"),
        };

        public static string GetCategoryKey(string value)
        {
            return Categories.SingleOrDefault(c => c.Value == value).Key;
        }
        public static string GetCategoryKeyByProductValue(string productValue)
        {
            return Products.SingleOrDefault(c => c.Value.ContainsValue(productValue)).Key;
        }
        public static string GetCategoryValue(string key)
        {
            return Categories.SingleOrDefault(c => c.Key == key).Value;
        }

        public static string GetProductByValue(string value)
        {
            return Products.SingleOrDefault(c => c.Value.ContainsValue(value)).Value.SingleOrDefault(p => p.Value == value).Key;
        }
    }
}
