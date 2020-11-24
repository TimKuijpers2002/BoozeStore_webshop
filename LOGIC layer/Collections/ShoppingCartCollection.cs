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
        /*public void Create(ShoppingCartModel cart)
        {
            
            var _dto = new DTOShoppingCart()
            {
                CartID = cart.CartID,
                CustomerID = ,
                TotalPrice = cart.TotalPrice,
                CreationTime = cart.CreationTime,
            };

            ShoppingCartFactory.shoppingCartConnectionHandler.CreateShoppingCart(_dto);
        }*/

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
    }
}
