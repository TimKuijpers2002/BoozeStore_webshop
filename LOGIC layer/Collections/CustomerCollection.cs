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
        public void Create(CustomerModel customer)
        {
            var _dto = new DTOCustomer()
            {
                CustomerID = customer.CustomerID,
                Name = customer.Name,
                Adress = customer.Adress,
                Email = customer.Email
            };

            CustomerFactory.customerConnectionHandler.CreateCustomer(_dto);
        }
    }
}
