using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAssessment.Models;
using LibraryAssessment.Services;

namespace LibraryAssessment.Controllers
{
    public class HomeController : Controller
    {

        private ITextFileOperations _textFileOperations;

        public HomeController(ITextFileOperations textFileOperations)
        {
            _textFileOperations = textFileOperations;

        }
        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to the Library Intranet";

            ViewBag.UserNew = new Users()
            {
                FirstName = "Tom",
                LastName = "Smith"
            };
            ViewData["AnotherWelcome"] = "Please enter your Name";

            //======= Conditions of Acceptance
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.

            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();

            return View();

        }

        

       

        public IActionResult about()
        {
            
           ViewData["Message"] = "Your Application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
