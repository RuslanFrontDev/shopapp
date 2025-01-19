using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;
        static ProductRepository()
        {
            _products = new List<Product>
            {
                 new Product{ProductId=1, Name = "iphone 5", Price=2000, IsApproved= true, ImageUrl = "1.jpg", CategoryId=1},
                new Product{ProductId=2,Name = "radio", Price=5000, IsApproved= false , ImageUrl = "1.jpg", CategoryId=3},
                new Product{ProductId=3,Name = "Lenova Komputer", Price=8000, IsApproved= false , ImageUrl = "1.jpg", CategoryId=2},
                 new Product{ProductId=4, Name = "iphone 8", Price=2000, IsApproved= true, ImageUrl = "1.jpg", CategoryId=1},
                new Product{ProductId=5,Name = "Qulaqciq", Price=5000, IsApproved= false , ImageUrl = "1.jpg", CategoryId=3},
                new Product{ProductId=6,Name = "Aus Komputer", Price=8000, IsApproved= false , ImageUrl = "1.jpg", CategoryId=2},


            };
        }
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }
        public static void EditProduct(Product product)
        {
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.ImageUrl = product.ImageUrl;
                    p.CategoryId = product.CategoryId;
                }
            }
        }
        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }


    }
}