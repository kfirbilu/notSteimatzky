using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Boolean Gender { get; set; }
        [Required]
        [Display(Name = "Is Manager")]
        public Boolean IsAdmin { get; set; }
    }
}
