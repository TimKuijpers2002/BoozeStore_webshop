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
        private readonly DrinkCollection drinkcollection = new DrinkCollection();
        private List<DrinkViewModel> DVM;
        public DrinkController()
        {
            //drinkmodel = new DrinkModel();
        }
        public IActionResult Index()
        {
            var all = drinkcollection.GetAllDrinks();
            DVM = new List<DrinkViewModel>();

            foreach (var drink in all)
            {
                DVM.Add(new DrinkViewModel
                {
                    DrinkID = drink.DrinkID,
                    Name = drink.Name,
                    Volume = drink.Volume,
                    AlcoholPercentage = drink.AlcoholPercentage,
                    AmountStored = drink.AmountStored,
                    Price = drink.Price,
                    ImageLink = drink.ImageLink
                });
            }
            return View(DVM);
        }

        public IActionResult Details(int? ID)
        {
            var all = drinkcollection.GetAllDrinks();
            DVM = new List<DrinkViewModel>();

            //If the ID isn't equil to Null-value, the if-statement is executed.
            if (ID != null)
            {
                //Here it count with int 'i' and it keeps counting 'til the max value of all is counted.
                for (int i = 0; i < all.Count; i++)
                {
                    //When ID is equil to all; the program will 'copy' all values of Vehicleviewmodel and add it to VVM.
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
