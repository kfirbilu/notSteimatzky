using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksStore.Views.Administrator
{
    public class EditUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }



    public class EditUserView  
    {
        public EditUserView()
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


        [CreditCard]
        public string CreditCard { get; set; }


        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }











}
