using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BooksStore.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }

        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public int? BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual List<OrderDetail> OrderDetailList { get; set; }

        public double OrderTotal { get; set; }
    }
}
