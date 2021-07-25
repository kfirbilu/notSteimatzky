using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BooksStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BooksStoreContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(BooksStoreContext context, ShoppingCart shoppingCart, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var username = await _userManager.GetUserAsync(User);

            ViewData["UserId"] = username.Id;

            ViewData["User"] = username;

            PopulateBranchesDropDownList();

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Terms()
        {
            var username = await _userManager.GetUserAsync(User);

            ViewData["UserId"] = username.Id;

            ViewData["User"] = username;

            PopulateBranchesDropDownList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([Bind("FirstName", "LastName", "User", "Address", "City", "Country", "Branch", "BranchId", "PhoneNumber", "UserId", "BookId","Book")] Order order, string userId)
        {
            _shoppingCart.ShoppingCartItems = GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                //ModelState.AddModelError("", "Your cart is empty");
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                ClearCart();

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult GetOrderDetails()
        {
            _shoppingCart.ShoppingCartItems = GetShoppingCartItems();

            int id = 1;

            var query = from p in _shoppingCart.ShoppingCartItems
                        where p != null
                        select new
                        {
                            // Changes
                            //Id = id++,
                            Book = p.Book.BookName,
                            //Quantity = p.Quantity,
                            Price = p.Book.Price * p.Quantity
                        };

            return Json(query.ToList());
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your product!";

            return View();
        }

        //////////////////////////////////////////////////////////////////////// Help methods //////////////////////

        // Build SelectList with all Branches
        private void PopulateBranchesDropDownList(object selectedBranch = null)
        {
            var branchesQuery = from b in _context.Branches
                                orderby b.BranchName
                                select b;
            ViewBag.BranchId = new SelectList(branchesQuery, "BranchId", "BranchName", selectedBranch);
        }

        // Place the order and save in the data base
        public void CreateOrder(Order order)
        {
            order.DateTime = DateTime.Now;
            order.OrderTotal = GetShoppingCartITotal();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var shoppingCartItems = GetShoppingCartItems();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = shoppingCartItem.Quantity,
                    Price = shoppingCartItem.Book.Price,
                    BookId = shoppingCartItem.Book.BookId,
                    BookName = shoppingCartItem.Book.BookName,
                    BookRating = 5,
                    OrderId = order.OrderId,
                    UserId = order.UserId
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }

        //Clear Cart after Complete Check out
        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        //Get the Total Price of all Items (Products) in th Cart
        public double GetShoppingCartITotal()
        {
            var total = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId)
                .Select(c => c.Book.Price * c.Quantity)
                .Sum();
            return total;
        }

        // Get from data base All the Books of the current Cart
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCart.ShoppingCartItems = _shoppingCart.ShoppingCartItems ?? (_shoppingCart.ShoppingCartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == _shoppingCart.ShoppingCartId)
                .Include(s => s.Book)
                .ToList());
        }

        public async Task<IActionResult> List()
        {
            var orders = _context.Orders.Where(o => o.UserId == _userManager.GetUserId(User));
            var ordersdetails = from od in _context.OrderDetails
                                join o in _context.Orders
                                on od.OrderId equals o.OrderId
                                select od;
            ViewData["OrdersDetails"] = await ordersdetails.ToListAsync();
            return View(await orders.ToListAsync());
        }
    }
}
