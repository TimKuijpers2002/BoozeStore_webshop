using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class ShoppingCartCollection
    {
        public List<ShoppingCartModel> GetAllShoppingCarts()
        {
            var result = ShoppingCartFactory.shoppingCartConnectionHandler.GetShoppingCarts();
            var cart = new List<ShoppingCartModel>();
            foreach (var dto in result)
            {
                cart.Add(new ShoppingCartModel(dto.CartID, dto.CustomerID, dto.TotalPrice, dto.CreationTime));
            }
            return cart;
        }

        public List<ShoppingCartModel> GetByCartID(string ID)
        {
            var result = GetAllShoppingCarts();
            List<ShoppingCartModel> carts = new List<ShoppingCartModel>();
            foreach (var item in result)
            {
                if (item.CartID == ID)
                {
                    carts.Add(item);
                }
            }
            return carts;
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
