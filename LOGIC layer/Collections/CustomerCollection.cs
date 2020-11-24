﻿using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CustomerCollection
    {
        public void Create(CustomerModel customer, ShoppingCartModel shoppingCartModel)
        {
            var ID = customer.GeneratedID();

            var _dto = new DTOCustomer()
            {
                CustomerID = ID,
                Name = customer.Name,
                Adress = customer.Adress,
                Email = customer.Email
            };
            CreateCart(shoppingCartModel, ID);
            CustomerFactory.customerConnectionHandler.CreateCustomer(_dto);
        }
        public void CreateCart(ShoppingCartModel cart, string customerID)
        {

            var _dto = new DTOShoppingCart()
            {
                CartID = cart.CartID,
                CustomerID = customerID,
                TotalPrice = cart.TotalPrice,
                CreationTime = cart.CreationTime,
            };

            ShoppingCartFactory.shoppingCartConnectionHandler.CreateShoppingCart(_dto);
        }
    }
}
