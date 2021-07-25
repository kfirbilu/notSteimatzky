using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Branch
    {
        [Key]
        [Display(Name = "Branch ID")]
        public int BranchId { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        //קו רוחב
        [Required]
        public double Latitude { get; set; }

        //קו אורך
        [Required]
        public double Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\(?(([0-9]{2})|([0-9]{3}))\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The number you entered is not valid")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
