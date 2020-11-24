using DAL_factory.Factories;
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
    }
}
