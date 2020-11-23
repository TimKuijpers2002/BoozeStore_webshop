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
        private readonly ShoppingCartCollection shoppingCartCollection = new ShoppingCartCollection();

        public IActionResult CreateCustomer(CustomerViewModel customerViewModel)
        {
            var customer = new CustomerModel(customerViewModel.CustomerID, customerViewModel.Name, customerViewModel.Adress, customerViewModel.Email);
            customerCollection.Create(customer);
            return RedirectToAction("Index", "Drink");
        }
    }
}
