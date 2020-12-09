using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CustomerCollection
    {
        private CartItemCollection cartColl;

        public CustomerCollection()
        {
            cartColl = new CartItemCollection();
        }
        public void Create(CustomerModel customer, ShoppingCartModel shoppingCartModel, List<CartItemModel> cartItemModel)
        {
            var ID = customer.GeneratedID();

            var _dto = new DTOCustomer()
            {
                CustomerID = ID,
                Name = customer.Name,
                Adress = customer.Adress,
                Email = customer.Email
            };

            customer.CreateCart(shoppingCartModel, ID);

            foreach (var item in cartItemModel)
            {
                var model = new CartItemModel(item.CartID, item.DrinkID, item.Quantity);
                cartColl.Create(model, ID);
            }

            CustomerFactory.customerConnectionHandler.CreateCustomer(_dto);
        }
    }
}
