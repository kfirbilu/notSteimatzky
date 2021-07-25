using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Components
{
    public class GenresMenu : ViewComponent
    {
        private readonly BooksStoreContext _context;

        public GenresMenu(BooksStoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var Genres = _context.Genres;

            return View(Genres);
        }
    }
}
