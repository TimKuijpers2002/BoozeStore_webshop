using DAL_layer.DataContext;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_factory.Factories
{
    public static class ShoppingCartFactory
    {
        private static IShoppingCartHandler _shoppingCartConnectionHandler;

        public static IShoppingCartHandler shoppingCartConnectionHandler
        {
            get
            {
                if (_shoppingCartConnectionHandler == null)
                {
                    _shoppingCartConnectionHandler = new ShoppingCartHandler(new DBConnectionHandler());
                }
                return _shoppingCartConnectionHandler;
            }
        }
    }
}
