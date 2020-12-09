using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoozeStore.Models;
using LOGIC_layer.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BoozeStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoppingCartCollection cartColl;
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        private List<CartItemViewModel> CIVM;

        public AdminController()
        {
            cartColl = new ShoppingCartCollection();
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
            CIVM = new List<CartItemViewModel>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Drinks()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var items = cartColl.GetAllShoppingCarts();
            var SVM = new List<ShoppingCartViewModel>();

            foreach(var order in items)
            {
                var currentOrder = new ShoppingCartViewModel()
                {
                    CartID = order.CartID,
                    CustomerID = order.CustomerID,
                    TotalPrice = order.TotalPrice,
                    CreationTime = order.CreationTime
                };
                SVM.Add(currentOrder);
            }
            return View(SVM);
        }

        public IActionResult OrderDetails(string ID)
        {
            var drinks = drinkColl.GetAllDrinks();
            var items = itemColl.GetByCartID(ID);
            foreach (var drink in items) {

                var result = drinks.Where(a => a.DrinkID == drink.DrinkID).ToList();
                foreach (var drinkresult in result) {
                    var order = new CartItemViewModel()
                    {
                        CartID = drink.CartID,
                        DrinkID = drink.DrinkID,
                        Quantity = drink.Quantity,
                        Name = drinkresult.Name,
                        ImageLink = drinkresult.ImageLink
                        
                    };
                    CIVM.Add(order);
                } 
            }

            return View(CIVM);
        }
    }
}
