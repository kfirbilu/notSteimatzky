using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
