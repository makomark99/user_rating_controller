using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SentimentBusinessLogic.DataTransferObjects;
using SentimentBusinessLogic.ViewModels;
using SentimentMVCPrezentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SentimentMVCPrezentation.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            var model = new PrivacyViewModel();
            model.PrivacyStatement = "BLBLLABLBLLALBLALABLBALLABLBALBLA";

            var rnd = new Random();
            var i = rnd.Next(0, 10);
            if (i >= 5)
            {
                return View("~/Views/Home/PrivacyAB.cshtml", model);
            }
            else
            {
                return View("~/Views/Home/Privacy.cshtml", model);
            }

        }

        public void Test(SearchPattern searchPattern)
        {
            //példányosítani valami BLL osztályt
            //annak továbbadni, visszakapun valami eredményt

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
