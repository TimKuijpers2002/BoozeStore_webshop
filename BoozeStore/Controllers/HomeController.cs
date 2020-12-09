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
            string Key = Convert.ToString(ID);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(7);

            if(Request.Cookies[Key] == null)
            {
                Response.Cookies.Append(Key, "1", cookie);
            }
            else
            {
                int quantity = Convert.ToInt32(Request.Cookies[Key]);
                quantity += 1;
                string value = Convert.ToString(quantity);
                Response.Cookies.Append(Key, value, cookie);
            }
            
            return RedirectToAction("Index", "Drink");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
