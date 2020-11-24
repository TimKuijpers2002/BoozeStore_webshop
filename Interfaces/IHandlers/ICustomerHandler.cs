using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface ICustomerHandler
    {
        void CreateCustomer(DTOCustomer C1);
        void DeleteCustomer(string ID);
        List<DTOCustomer> GetCustomers();
    }
}
