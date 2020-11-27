using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CartItemCollection
    {
        public void Create(CartItemModel cartItemModel)
        {
            var _dto = new DTOOrder()
            {
                CartID = cartItemModel.CartID,
                DrinkID = cartItemModel.DrinkID,
                Quantity = cartItemModel.Quantity
            };
            CartItemFactory.orderConnectionHandler.CreateOrder(_dto);
        }

        public List<CartItemModel> GetAllOrders()
        {
            var result = CartItemFactory.orderConnectionHandler.GetOrders();
            var order = new List<CartItemModel>();
            foreach (var dto in result)
            {
                order.Add(new CartItemModel(dto.CartID, dto.DrinkID, dto.Quantity));
            }
            return order;
        }
    }
}
