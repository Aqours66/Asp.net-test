using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class CartController : Controller
    {
        private static List<CartItem> cartItems = new List<CartItem>();

        public IActionResult Index()
        {
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            var product = ProductController.Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var cartItem = cartItems.Find(c => c.ProductId == id);
            if (cartItem == null)
            {
                cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = 1,
                    Price = product.Price
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            // Implement checkout logic here
            return View();
        }
    }
}
