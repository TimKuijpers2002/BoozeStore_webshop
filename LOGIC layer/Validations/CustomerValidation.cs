using LOGIC_layer.Collections;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Validations
{
    public class CustomerValidation
    {
        public bool isCustomerNew(CustomerModel customer, List<CustomerModel> AllCustomers)
        {
            return AllCustomers.Any(c => c.Email == customer.Email);
        }

        public List<CustomerModel> getExistingCustomer(string email, List<CustomerModel> AllCustomers)
        {
            var allCustomers = AllCustomers;
            var customer = allCustomers.Where(c => c.Email.Contains(email)).ToList();
            return customer;
        }
    }
}
