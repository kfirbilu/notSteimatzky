using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data;
using BooksStore.Models;
using Microsoft.EntityFrameworkCore;
using BooksStore.Views.ShoppingCarts;

namespace BooksStore.Components
{
    [ViewComponent(Name = "ShoppingCartSummary")]
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly BooksStoreContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(BooksStoreContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.ShoppingCartItems ??
                (_shoppingCart.ShoppingCartItems = _context.ShoppingCartItems.Where
                (c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Include(s => s.Book).ToList());

            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId)
                .Select(c => c.Book.Price * c.Quantity).Sum();

            var shoppingCartViewModel = new ShoppingCartView 
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = total
            };

            return View(shoppingCartViewModel);
        }

    }
}
