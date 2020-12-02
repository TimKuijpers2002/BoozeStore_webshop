using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoozeStore.Models;
using LOGIC_layer.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BoozeStore.Controllers
{
    public class CartController : Controller
    {
        private readonly DrinkCollection drinkcollection = new DrinkCollection();
        private List<DrinkViewModel> DVM;

        public IActionResult Index()
        {
            string cookieValue = Request.Cookies["shoppingcart"];

            List<string> DrinkIDs = cookieValue.Split('I').ToList();
            DrinkIDs.Remove(DrinkIDs[DrinkIDs.Count - 1]);
            List<int> _DrinkIDs = DrinkIDs.Select(int.Parse).ToList();
            var all = drinkcollection.GetAllDrinks();
            DVM = new List<DrinkViewModel>();

            if (DrinkIDs != null)
            {
                for (int j = 0; j < DrinkIDs.Count; j++) { 

                    for (int i = 0; i < DrinkIDs.Count; i++)
                    {
                        if (_DrinkIDs[j] == all[i].DrinkID)
                        {
                            var viewmodel = new DrinkViewModel()
                            {
                                DrinkID = all[i].DrinkID,
                                Name = all[i].Name,
                                Volume = all[i].Volume,
                                AlcoholPercentage = all[i].AlcoholPercentage,
                                AmountStored = all[i].AmountStored,
                                Price = all[i].Price,
                                ImageLink = all[i].ImageLink

                            };
                            DVM.Add(viewmodel);
                        }
                    }
                }
            }
            else
            {
                //Hier kan een exception komen voor meer voortgang.
            }

            return View(DVM);
        }
    }
}
