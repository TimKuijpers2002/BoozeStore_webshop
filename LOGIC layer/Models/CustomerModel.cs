using DAL_factory.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; }
        public string Name { get; }
        public string Adress { get; }
        public string Email { get; }

        public CustomerModel(int customerID, string name, string adress, string email)
        {
            CustomerID = customerID;
            Name = name;
            Adress = adress;
            Email = email;
        }

        public void Delete(int customerID)
        {
            CustomerFactory.customerConnectionHandler.DeleteCustomer(customerID);
        }
    }
}
