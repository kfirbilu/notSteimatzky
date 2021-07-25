using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "Book ID")]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Publication { get; set; }

        public string Summary { get; set; }

        [Display(Name = "Picture")]
        public string PictureName { get; set; }

        [Display(Name ="Genre")]
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
