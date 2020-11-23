using DAL_layer.DataContext;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_factory.Factories
{
    public static class CustomerFactory
    {
        private static ICustomerHandler _customerConnectionHandler;

        public static ICustomerHandler customerConnectionHandler
        {
            get
            {
                if (_customerConnectionHandler == null)
                {
                    _customerConnectionHandler = new CustomerHandler(new DBConnectionHandler());
                }
                return _customerConnectionHandler;
            }
        }
    }
}
