using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoozeStore.Models;
using LOGIC_layer.Models;
using LOGIC_layer.Collections;

namespace BoozeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShoppingCartModel shoppingCartModel;
        private readonly ShoppingCartCollection shoppingCartCollection = new ShoppingCartCollection();
        private List<ShoppingCartViewModel> SCVM;

        public IActionResult Index()
        {
            //VRAAG DIT EVEN NA!!
            //shoppingCartCollection.Create(ShoppingCartModel cart);

            //ShoppingCartCollection.Create(cart);
            TempData["Create"] = "The records has been added to the system!";
            return RedirectToAction("Index", "Drink");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
