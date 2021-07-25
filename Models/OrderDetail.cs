using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int BookRating { get; set; }

        public string BookName { get; set; }
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual Book Book { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}
