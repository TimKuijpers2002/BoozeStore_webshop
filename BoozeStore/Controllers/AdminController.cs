using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoozeStore.Models;
using LOGIC_layer.Collections;
using LOGIC_layer.Models;
using LOGIC_layer.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BoozeStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoppingCartCollection cartColl;
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        private readonly CustomerCollection customerColl;
        private readonly CartItemSpecificsCollection specificColl;
        private List<CartItemViewModel> CIVM;
        private List<DrinkViewModel> DVM;
        private readonly DrinkValidation drinkVal;

        public AdminController()
        {
            cartColl = new ShoppingCartCollection();
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
            customerColl = new CustomerCollection();
            specificColl = new CartItemSpecificsCollection();
            CIVM = new List<CartItemViewModel>();
            drinkVal = new DrinkValidation();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Drinks()
        {
            DVM = new List<DrinkViewModel>();
            var all = drinkColl.GetAllDrinks();

            foreach (var drink in all)
            {
                DrinkViewModel viewModel = new DrinkViewModel() { DrinkID = drink.DrinkID, Name = drink.Name, Volume = drink.Volume, AlcoholPercentage = drink.AlcoholPercentage, AmountStored = drink.AmountStored, Price = drink.Price, ImageLink = drink.ImageLink };
                DVM.Add(viewModel);
            }
            return View(DVM);
        }

        public IActionResult Orders()
        {
            var items = cartColl.GetAllShoppingCarts();
            var SVM = new List<ShoppingCartViewModel>();
            var customers = customerColl.GetAllCustomers();
            foreach(var order in items)
            {
                var ID = customers.Where(c => c.CustomerID.Contains(order.CustomerID)).ToList();
                    var currentOrder = new ShoppingCartViewModel()
                    {
                        CartID = order.CartID,
                        CustomerID = order.CustomerID,
                        Name = ID.First().Name,
                        TotalPrice = order.TotalPrice,
                        CreationTime = order.CreationTime
                    };
                    SVM.Add(currentOrder);
            }
            return View(SVM);
        }

        public IActionResult OrderDetails(string ID)
        {
            var specifics = specificColl.GetAllSpecificsWithCartID(ID);

            foreach (var item in specifics)
            {
                var viewmodel = new CartItemViewModel()
                {
                    CartID = item.CartID,
                    DrinkID = item.DrinkID,
                    Quantity = item.Quantity,
                    Name = item.Name,
                    ImageLink = item.ImageLink,
                    Price = item.Price
                };

                CIVM.Add(viewmodel);
            }

            return View(CIVM);
        }

        public IActionResult DeleteOrder(string ID)
        {
            var items = itemColl.GetAllOrders();
            var carts = cartColl.GetByCartID(ID);
            foreach (var cart in carts) {
                
                foreach (var item in items)
                {
                    item.Delete(ID);
                }
                cart.Delete(ID);
            }
            return RedirectToAction("Orders");
        }

        public IActionResult CreateDrinkPage()
        {
            return View();
        }

        public IActionResult Create(DrinkViewModel drinkViewModel)
        {
            var tempID = 0;
            DrinkModel drinkModel = new DrinkModel(tempID, drinkViewModel.Name, drinkViewModel.Volume, drinkViewModel.AlcoholPercentage, drinkViewModel.AmountStored, drinkViewModel.Price, drinkViewModel.ImageLink);
            if (!drinkVal.isCustomerNew(drinkModel, drinkColl.GetAllDrinks()))
            {
                drinkColl.Create(drinkModel);
                return RedirectToAction("Drinks", "Admin");
            }
            else
            {
                TempData["drinkerror"] = "Drink already exists";
                return RedirectToAction("CreateDrinkPage", "Admin");
            }
        }

        public IActionResult Delete(int ID)
        {
            var drink = drinkColl.GetDrinkByID(ID).First();
            drink.Delete(ID);
            return RedirectToAction("Drinks", "Admin");
        }
    }
}
