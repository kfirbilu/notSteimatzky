using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BooksStore.Models
{
    public class ShoppingCart
    {
        private readonly BooksStoreContext _booksStoreContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(BooksStoreContext booksStoreContext)
        {
            _booksStoreContext = booksStoreContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<BooksStoreContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
    }
}
