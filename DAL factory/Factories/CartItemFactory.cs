using DAL_layer.DataContext;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_factory.Factories
{
    public class CartItemFactory
    {
        private static ICartItemsHandler _orderConnectionHandler;

        public static ICartItemsHandler orderConnectionHandler
        {
            get
            {
                if (_orderConnectionHandler == null)
                {
                    _orderConnectionHandler = new CartItemsHandler(new DBConnectionHandler());
                }
                return _orderConnectionHandler;
            }
        }
    }
}
