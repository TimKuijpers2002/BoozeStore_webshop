using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoozeStore.Models;
using LOGIC_layer.Models;
using LOGIC_layer.Collections;
using Microsoft.AspNetCore.Http;

namespace BoozeStore.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Drink");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StoreValuesCookie(int ID)
        {
            string Key = "shoppingcart";
            string value = Request.Cookies["shoppingcart"];
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(Key, Convert.ToString(ID) + "I" + value, cookie);
            return RedirectToAction("Index", "Drink");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
