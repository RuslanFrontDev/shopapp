using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("api/product/index")]
        public IActionResult Index()
        {
            var p = new Product()
            {
                Name = "Iphone",
                Price = 5000,
            };
            return Ok(p);
        }
        [HttpGet("api/product/list")]
        public IActionResult List(int? id, string q)
        {
            Console.WriteLine(q);
            var productViewModel = ProductRepository.Products;

            if (id != null)
            {
                productViewModel = productViewModel.Where(x => x.CategoryId == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                productViewModel = productViewModel.Where(i => i.Name.ToLower().Contains(q.ToLower())).ToList();
            }

            var filteredProducts = productViewModel.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Price,
                product.ImageUrl
            }).ToList();

            return Ok(new { products = filteredProducts });
        }

        [HttpGet("api/product/details/{id}")]
        public IActionResult Details(int id)
        {
            var product = ProductRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }
        [HttpGet("api/product/create")]
        public IActionResult Create()
        {
            var categories = CategoryRepository.Categories.Select(c => new
            {
                value = c.CategoryId,
                text = c.Name
            });

            return Ok(new { categories });
        }

        [HttpPost("api/product/create")]
        public IActionResult Create(Product p)
        {
            // Validate the product data
            ProductRepository.AddProduct(p);

            // Correct usage of RedirectToAction with double quotes
            return RedirectToAction("list");
        }
        [HttpGet("api/product/edit")]
        public IActionResult Edit(int id)
        {
            return Ok(ProductRepository.GetProductById(id));
        }
        [HttpPost("api/product/edit")]
        public IActionResult Edit(Product p)
        {
            // Validate the product data
            ProductRepository.EditProduct(p);

            // Correct usage of RedirectToAction with double quotes
            return RedirectToAction("list");
        }
        [HttpDelete("api/product/delete/{id}")]
        public IActionResult Delete(int id)
        {
            ProductRepository.DeleteProduct(id);
            return NoContent(); // or return an appropriate response like RedirectToAction("list")
        }





    }
}