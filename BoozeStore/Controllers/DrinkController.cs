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
    public class DrinkController : Controller
    {
        private readonly DrinkModel drinkmodel;
        private readonly DrinkCollection drinkcollection;
        private List<DrinkViewModel> DVM;
        public DrinkController()
        {
            drinkcollection = new DrinkCollection();
        }
        public IActionResult Index(string SearchText)
        {
            DVM = new List<DrinkViewModel>();

            var drinkResults = drinkcollection.SearchForDrinks(SearchText);
            foreach(var drink in drinkResults)
            {
                DrinkViewModel viewModel = new DrinkViewModel() { DrinkID = drink.DrinkID, Name = drink.Name, Volume = drink.Volume, AlcoholPercentage = drink.AlcoholPercentage, AmountStored = drink.AmountStored, Price = drink.Price, ImageLink = drink.ImageLink };
                DVM.Add(viewModel);
            }

            return View(DVM);
        }

        public IActionResult Details(int? ID)
        {
            var all = drinkcollection.GetAllDrinks();
            DVM = new List<DrinkViewModel>();

            if (ID != null)
            {
                for (int i = 0; i < all.Count; i++)
                {
                    if (ID == all[i].DrinkID)
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
            else
            {
                //Hier kan een exception komen voor meer voortgang.
            }

            return View(DVM);
        }
    }
}
