using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeterGardinerAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment3.Controllers
{
    public class HomeController : Controller
    {

        private MovieListContext context { get; set; }

        public HomeController(MovieListContext movielist)
        {
            context = movielist;
        }

        //return home page
        public IActionResult Index()
        {
            return View();
        }

        //get for movie form

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        //post form if model state is valid
        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse AppResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(AppResponse);
                context.SaveChanges();
            }

                return View();
            
        }

        //returns movie list 
        public IActionResult MovieList(ApplicationResponse AppResponse)
        {
            return View(Storage.Applications);
        }

        //returns podcast page
        public IActionResult Podcasts()
        {
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
    }
}
