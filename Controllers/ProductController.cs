using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.00M, ImageUrl = "/images/product1.jpg" },
            new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.00M, ImageUrl = "/images/product2.jpg" },
            new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.00M, ImageUrl = "/images/product3.jpg" }
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Details(int id)
        {
            var product = Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
