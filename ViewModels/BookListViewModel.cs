using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentGenre { get; set; }
        public string CurrentBookName { get; set; }
    }
}
