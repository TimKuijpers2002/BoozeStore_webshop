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
        private readonly CustomerCollection customerCollection;
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        private readonly ShoppingCartCollection cartColl;
        private readonly string tempid = "TempID";
        private  ShoppingCartModel shoppingCartModel;
        private CustomerModel customerModel;
        private List<CartItemModel> CIM;
        private decimal totalPrice;

        public CustomerController()
        {
            customerCollection = new CustomerCollection();
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
            CIM = new List<CartItemModel>();
            cartColl = new ShoppingCartCollection();
        }

        public IActionResult CreateCustomer(CustomerViewModel customerViewModel)
        {
            List<string> DrinkIDs = Request.Cookies.Keys.ToList();
            var drinks = drinkColl.GetAllDrinks();

            var itemsModel = itemColl.GetDrinkByIDs(DrinkIDs, drinks);

            foreach (var item in itemsModel)
            {
                var cartItem = new CartItemModel(item.CartID, item.DrinkID, Convert.ToInt32(Request.Cookies[Convert.ToString(item.DrinkID)]));
                CIM.Add(cartItem);
            }

            
            var TotalPrice = cartColl.GetTotalPrice(CIM, drinks, totalPrice);
            shoppingCartModel = new ShoppingCartModel(tempid, tempid, TotalPrice, DateTime.Now);

            customerModel = new CustomerModel(customerViewModel.CustomerID, customerViewModel.Name, customerViewModel.Adress, customerViewModel.Email);
            customerCollection.Create(customerModel,shoppingCartModel, CIM);
            return RedirectToAction("Index", "Drink");
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
