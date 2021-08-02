using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksStore.Views.Books
{
    public class ListModel : PageModel
    {
        public void OnGet()
        {
        }
    }



    public class BookListView
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentGenre { get; set; }
        public string CurrentBookName { get; set; }
    }






}





