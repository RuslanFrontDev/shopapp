using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;
using shopapp.webui.Models;
using shopapp.webui.ViewModel;
// using perferina.webui.Data;


namespace shopapp.webui.Controllers
{
    public class HomeController : Controller
    {
        // private IProductRepository _productRepository;
        // public HomeController(IProductRepository productRepository)
        // {
        //     this._productRepository = productRepository;
        // }



        [HttpGet("api/home/index")]

        public IActionResult Index()
        {

            var categories = new List<Category>() {
                new Category{Name = "Telefon",  Description= "Telefon Kategoriyasi"},
                new Category{Name = "Komputer", Description= "Komputer Kategoriyasi"},
                new Category{Name = "Elektronika", Description= "Elektronik Kategoriyasi"},
            };
            var productViewModel = new ProductViewModel()
            {
                Categories = categories,
                Products = ProductRepository.Products
            };
            return Ok(productViewModel);
        }
        [HttpGet("api/home/about")]
        public string About()
        {
            return "home/about";
        }
    }
}