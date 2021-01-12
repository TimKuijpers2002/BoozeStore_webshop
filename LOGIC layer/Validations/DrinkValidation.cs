using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Validations
{
    public class DrinkValidation
    {
        public bool isCustomerNew(DrinkModel drink, List<DrinkModel> AllDrinks)
        {
            return AllDrinks.Any(c => c.Name == drink.Name);
        }
    }
}
