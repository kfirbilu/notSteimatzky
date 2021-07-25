using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();

            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
