using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CV_creator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var randomGuids = new List<Guid>();
            for (int i = 0; i < 10; i++)
            { 
                randomGuids.Add(Guid.NewGuid()); 
            }


            return View(randomGuids);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(BasicInformation data)
        {
            //save, edit, etc
            // if error return to the same view with model
            if (ModelState.IsValid) 
            {
                return RedirectToAction("Index");
            }

            return View(data);
            //if no error
            //return RedirectToAction("Index")
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
