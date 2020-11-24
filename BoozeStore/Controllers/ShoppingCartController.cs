using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoozeStore.Models;
using LOGIC_layer.Collections;
using LOGIC_layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoozeStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        public readonly ShoppingCartCollection shoppingCartCollection = new ShoppingCartCollection();
        public IActionResult Index()
        {
            return View();
        }
    }
}
