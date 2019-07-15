using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilterDotNetCore.Models;
using FilterDotNetCore.FIlter;

namespace FilterDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        [CustomResult("Ashutosh")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            try
            {
                var i = 0;
                var j = 100;
                var divide = j / i;
                ViewData["Message"] = "Your application description page.";

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          

         
        }

        public IActionResult Contact()
        {
            try
            {
                ApplicationUser user = new ApplicationUser();
                var users = User.Claims.Where(X => X.Type == "tesd");
                var data = users.Take(1).ToList();
                  data.RemoveAt(1);
           
                ViewData["Message"] = "Your contact page.";

                return View();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        [ClaimRequirement()]
        public IActionResult TestForAuthoriation()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
