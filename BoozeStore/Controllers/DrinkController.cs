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
    }
}
