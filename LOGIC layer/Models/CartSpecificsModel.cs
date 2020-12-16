using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class CartSpecificsModel
    {
        public string Name { get; }
        public decimal Price { get; }
        public string ImageLink { get; }
        public string CartID { get; }
        public int DrinkID { get; }
        public int Quantity { get; }

        public CartSpecificsModel(string name, decimal price, string imageLink, string cartID, int drinkID, int quantity)
        {
            Name = name;
            Price = price;
            ImageLink = imageLink;
            CartID = cartID;
            DrinkID = drinkID;
            Quantity = quantity;
        }
    }
}
