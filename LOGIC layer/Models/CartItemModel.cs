using DAL_factory.Factories;
using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class CartItemModel
    {
        public string CartID { get; }
        public int DrinkID { get; }
        public int Quantity { get; }

        public CartItemModel(string cartID, int drinkID, int quantity)
        {
            CartID = cartID;
            DrinkID = drinkID;
            Quantity = quantity;
        }

        public void Delete(string cartID)
        {
            CartItemFactory.orderConnectionHandler.DeleteOrder(cartID);

        }
        public void Update(CartItemModel cartItems)
        {
            var _dto = new DTOOrder()
            {
                CartID = cartItems.CartID,
                DrinkID = cartItems.DrinkID,
                Quantity = cartItems.Quantity,
            };

            CartItemFactory.orderConnectionHandler.UpdateOrder(_dto);
        }
    }
}
