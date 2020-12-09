using DAL_factory.Factories;
using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class ShoppingCartModel
    {
        public string CartID { get; }
        public string CustomerID { get; }
        public decimal TotalPrice { get; }
        public DateTime CreationTime { get; }

        public ShoppingCartModel(string cartID, string customerID, decimal totalPrice, DateTime creationTime)
        {
            CartID = cartID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            CreationTime = creationTime;
        }

        public void Delete(int cartID)
        {
            ShoppingCartFactory.shoppingCartConnectionHandler.DeleteShoppingCart(cartID);
        }

        public void Update(ShoppingCartModel cart)
        {
            var _dto = new DTOShoppingCart()
            {
                CartID = cart.CartID,
                CustomerID = cart.CustomerID,
                TotalPrice = cart.TotalPrice,
                CreationTime = cart.CreationTime,
            };

            ShoppingCartFactory.shoppingCartConnectionHandler.UpdateShoppingCart(_dto);
        }

        public decimal GetTotalPrice(List<CartItemModel> cim, List<DrinkModel> dm, decimal totalPrice)
        {
            var TotalPrice = totalPrice;

            foreach (var item in cim) 
            {
                for (int i = 0; i < dm.Count; i++)
                {
                    if (item.DrinkID == dm[i].DrinkID)
                    {
                        var DrinkTotalPrice = item.Quantity * dm[i].Price;
                        TotalPrice += DrinkTotalPrice;
                    }
                }
            }

            return TotalPrice;
        }
    }
}
