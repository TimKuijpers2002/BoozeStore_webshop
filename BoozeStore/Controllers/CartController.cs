using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoozeStore.Models;
using LOGIC_layer.Collections;
using LOGIC_layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoozeStore.Controllers
{
    public class CartController : Controller
    {
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        private readonly CartItemSpecificsCollection specificColl;
        private List<CartItemViewModel> DVM;
        private List<DrinkModel> DM;

        public CartController()
        {
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
            specificColl = new CartItemSpecificsCollection();
            DVM = new List<CartItemViewModel>();
        }

        public IActionResult Index()
        {
            List<string> DrinkIDs = Request.Cookies.Keys.ToList();
            var drinks = drinkColl.GetAllDrinks();
            var specifics = specificColl.GetAllSpecificsWithDrinkID(DrinkIDs, drinks);

            foreach (var item in specifics)
            {
                    var viewmodel = new CartItemViewModel()
                    {
                        CartID = item.CartID,
                        DrinkID = item.DrinkID,
                        Quantity = Convert.ToInt32(Request.Cookies[Convert.ToString(item.DrinkID)]),
                        Name = item.Name,
                        ImageLink = item.ImageLink,
                        Price = item.Price
                    };

                    DVM.Add(viewmodel);
                }
            return View(DVM);
        }

        public IActionResult RemoveValueCookie(int ID)
        {
            string Key = Convert.ToString(ID);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(7);

                int quantity = Convert.ToInt32(Request.Cookies[Key]);
                if (quantity > 1)
                {
                    quantity -= 1;
                    string value = Convert.ToString(quantity);
                    Response.Cookies.Append(Key, value, cookie);
                }
                else
                {
                Response.Cookies.Delete(Key);
                }

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult AddValueCookie(int ID)
        {
            string Key = Convert.ToString(ID);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(7);

            int quantity = Convert.ToInt32(Request.Cookies[Key]);
            
                quantity += 1;
                string value = Convert.ToString(quantity);
                Response.Cookies.Append(Key, value, cookie);

            return RedirectToAction("Index", "Cart");
        }

    }
}
