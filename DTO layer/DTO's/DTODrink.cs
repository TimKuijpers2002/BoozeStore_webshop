using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_layer.DTO_s
{
    public class DTODrink
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public int Volume { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public int AmountStored { get; set; }
        public decimal Price { get; set; }
    }
}
