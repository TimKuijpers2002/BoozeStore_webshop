using DAL_factory.Factories;
using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class CustomerModel
    {
        public string CustomerID { get; }
        public string Name { get; }
        public string Adress { get; }
        public string Email { get; }

        public CustomerModel(string customerID, string name, string adress, string email)
        {
            CustomerID = customerID;
            Name = name;
            Adress = adress;
            Email = email;
        }

        public void Delete(string customerID)
        {
            CustomerFactory.customerConnectionHandler.DeleteCustomer(customerID);
        }

        public string GeneratedID()
        {
            string id = Guid.NewGuid().ToString();
            return id;
        }

        public void CreateCart(ShoppingCartModel cart, string customerID)
        {

            var _dto = new DTOShoppingCart()
            {
                CartID = customerID,
                CustomerID = customerID,
                TotalPrice = cart.TotalPrice,
                CreationTime = cart.CreationTime,
            };

            ShoppingCartFactory.shoppingCartConnectionHandler.CreateShoppingCart(_dto);
        }
    }
}
