using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksStore.Views.Admin
{
    public class CreateRoleModel : PageModel
    {
        public void OnGet()
        {
        }
    }


    public class CreateRoleView  
    {
        [Required]
        public string RoleName { get; set; }
    }




}
