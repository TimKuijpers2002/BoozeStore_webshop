using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CartItemCollection
    {
        public void Create(CartItemModel cartItemModel, string ID)
        {
            var _dto = new DTOOrder()
            {
                CartID = ID,
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

        public List<CartItemModel> GetDrinkByIDs(List<string> keyIDs, List<DrinkModel> drinks)
        {
            List<int> _DrinkIDs = keyIDs.Select(int.Parse).ToList();
            var DM = new List<CartItemModel>();

            if (drinks != null)
            {
                for (int j = 0; j < _DrinkIDs.Count; j++)
                {

                    for (int i = 0; i < drinks.Count; i++)
                    {
                        if (_DrinkIDs[j] == drinks[i].DrinkID)
                        {
                            int Key = drinks[i].DrinkID;
                            var model = new CartItemModel("0", drinks[i].DrinkID, 0);
                            DM.Add(model);
                        }
                    }
                }
            }
            else
            {

            }
            return DM;
        }

        public List<CartItemModel> GetByCartID(string ID)
        { 
                var result = GetAllOrders();
                List<CartItemModel> order = new List<CartItemModel>();
                foreach (var item in result)
                {
                    if (item.CartID == ID)
                    {
                        order.Add(item);
                    }
                }
                return order;
        }

    }
}
