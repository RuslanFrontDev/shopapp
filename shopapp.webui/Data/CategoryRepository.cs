using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = null;
        static CategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category{CategoryId=1, Name = "Telefon", Description= "Telefon", },
                new Category{CategoryId=2,Name = "Komputer", Description= "Komputer", },
                new Category{CategoryId=3,Name = "Elektronik", Description= "Elektronik", },
                new Category{CategoryId=4,Name = "Dizayn", Description= "Dizayn", },

            };
        }
        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public static void AddProduct(Category category)
        {
            _categories.Add(category);
        }
        public static Category GetProductById(int id)
        {
            return _categories.FirstOrDefault(p => p.CategoryId == id);
        }
    }
}