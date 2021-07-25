using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BooksStore.Models;
using BooksStore.Data;
using Microsoft.EntityFrameworkCore;
//using BooksStoreML.Model;
using System.Security.Claims;
using Microsoft.ML;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly BooksStoreContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        //public HomeController(ILogger<HomeController> logger)
        public HomeController(BooksStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Genres"] = _context.Genres.Include(g => g.BookList).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //[Authorize]
        //public async Task<string> Recommend()
        //{
        //    ModelInput input = new ModelInput();
        //    input.BookRating = 5;
        //    input.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    try
        //    {

        //        var username = _userManager.GetUserAsync(HttpContext.User).Id;
        //        input.BookName = _context.OrderDetails.FirstOrDefault(c => c.UserId == username.ToString())?.BookName;

        //    }
        //    catch (NullReferenceException e)
        //    {
        //        return "Sorry this feature is not avaliable... come back soon";
        //    }

        //    ModelOutput result = ConsumeModel.Predict(input);
        //    int rating = (int)result.Score;
        //    return rating.ToString();
        //}
    }
}
