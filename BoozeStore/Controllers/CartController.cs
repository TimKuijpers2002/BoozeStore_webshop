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
    public class CartController : Controller
    {
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        private List<CartItemViewModel> DVM;
        private List<DrinkModel> DM;

        public CartController()
        {
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
        }

        public IActionResult Index()
        {
            List<string> DrinkIDs = Request.Cookies.Keys.ToList();
            var drinks = drinkColl.GetAllDrinks();
            DVM = new List<CartItemViewModel>();

            var items = itemColl.GetDrinkIDs(DrinkIDs, drinks);
            foreach (var drink in items)
            {
                var result = drinks.Where(a => a.DrinkID == drink.DrinkID).ToList();

                foreach (var drinkresult in result) {
                    var viewmodel = new CartItemViewModel()
                    {
                        CartID = drink.CartID,
                        DrinkID = drink.DrinkID,
                        Quantity = Convert.ToInt32(Request.Cookies[Convert.ToString(drink.DrinkID)]),
                        Name = drinkresult.Name,
                        ImageLink = drinkresult.ImageLink,
                        Price = drinkresult.Price
                    };

                    DVM.Add(viewmodel);
                }
            }

            return View(DVM);
        }
    }
}
