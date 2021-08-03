using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
using BooksStore.Views.ShoppingCarts;

namespace BooksStore.Controllers
{


    public class ShoppingCartsController : Controller
    {
        private readonly BooksStoreContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartsController(BooksStoreContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            // Get from data base and View All the Products of the current Cart
            _shoppingCart.ShoppingCartItems = _shoppingCart.ShoppingCartItems ?? (_shoppingCart.ShoppingCartItems = await _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId)
                .Include(s => s.Book)
                .ToListAsync());

            var shoppingCartViewModel = new ShoppingCartView 
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = await GetShoppingCartITotal()
            };

            return View(shoppingCartViewModel);
        }

        public IActionResult ShoppingCartSummary(int bookId)
        {
            var selectedBook = GetAllBooks.FirstOrDefault(c => c.BookId == bookId);

            if (selectedBook != null)
            {
                AddToCart(selectedBook, 1);
            }

            return ViewComponent("ShoppingCartSummary");
        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = GetAllBooks.FirstOrDefault(c => c.BookId == bookId);

            if (selectedBook != null)
            {
                await RemoveFromCart(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int bookId)
        {
            var selectedBook = GetAllBooks.FirstOrDefault(c => c.BookId == bookId);

            if (selectedBook != null)
            {
                await AddToCart(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> ClearFromShoppingCart(int bookId)
        {
            var selectedBook = GetAllBooks.FirstOrDefault(c => c.BookId == bookId);

            if (selectedBook != null)
            {
                await ClearFromCart(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> ClearCart()
        {
            var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Helpers
        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                return _context.Books.Include(c => c.Genre);
            }
        }


        // Add a book to the Cart and Save it (the item) in the Data Base, ShoppingCartItems table
        public void AddToCart(Book book, int quantity)
        {

            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault
                (s => s.Book.BookId == book.BookId && s.ShoppingCartId == _shoppingCart.ShoppingCartId);

            // if If the condition is true: We are creating a new instance of ShoppingCartItem about the Book (not instance of Shopping Cart)
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = _shoppingCart.ShoppingCartId,
                    Book = book,
                    Quantity = quantity
                };

                // Add this new Item into the same Shopping Cart
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            // Else if the Item allready exists in the same Shopping Cart
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }


        //Remove an Item (Book) From the Cart and Save Changes in the Data Base, ShoppingCartItems table
        public async Task<int> RemoveFromCart(Book book)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.SingleOrDefaultAsync
                (s => s.Book.BookId == book.BookId && s.ShoppingCartId == _shoppingCart.ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            await _context.SaveChangesAsync();

            return localAmount;
        }

        //Adds an Item (Book) From the Cart and Save Changes in the Data Base, ShoppingCartItems table
        public async Task<int> AddToCart(Book book)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.SingleOrDefaultAsync
                (s => s.Book.BookId == book.BookId && s.ShoppingCartId == _shoppingCart.ShoppingCartId);

            var localAmount = 0;

                if (shoppingCartItem.Quantity >= 1)
                {
                    shoppingCartItem.Quantity++;
                    localAmount = shoppingCartItem.Quantity;
                }

            await _context.SaveChangesAsync();
            return localAmount;
        }

        //Clears an Item (Book) From the Cart and Save Changes in the Data Base, ShoppingCartItems table
        public async Task<int> ClearFromCart(Book book)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.SingleOrDefaultAsync
                (s => s.Book.BookId == book.BookId && s.ShoppingCartId == _shoppingCart.ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);  
            }

            await _context.SaveChangesAsync();

            return localAmount;
        }

        public async Task<double> GetShoppingCartITotal()
        {
            var totalPrice = await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Select(c => c.Book.Price * c.Quantity).SumAsync();
            return totalPrice;
        }
    }
}
