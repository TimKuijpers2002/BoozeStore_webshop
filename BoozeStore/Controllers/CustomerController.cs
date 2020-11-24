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
    public class CustomerController : Controller
    {
        private readonly CustomerCollection customerCollection = new CustomerCollection();

        public IActionResult CreateCustomer(CustomerViewModel customerViewModel)
        {
            var shoppingcart = new ShoppingCartModel(0, "0id", 10m, DateTime.Now);
            var customer = new CustomerModel(customerViewModel.CustomerID, customerViewModel.Name, customerViewModel.Adress, customerViewModel.Email);
            customerCollection.Create(customer,shoppingcart);
            return RedirectToAction("Index", "Drink");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
