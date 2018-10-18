using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using forex4u.Models;
using forex4u.Repositories;

namespace forex4u.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository userRepository;
        public HomeController(IUserRepository repository) => userRepository = repository;
        public IActionResult Index()
        {
            TestMethod();

            return View();
        }

        private void TestMethod()
        {
            try
            {
                StockUser stockUser = new StockUser()
                {
                    Email = "ali@g.com",
                    FirstName = "ali",
                    LastName = "garom",
                    MobileNumber = "09124568897",
                    WebPassword = "1234qwer"
                };

                userRepository.Add(stockUser);
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Forex4u.ir web application ";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
