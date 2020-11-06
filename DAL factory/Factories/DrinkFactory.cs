using DAL_layer.DataContext;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_factory.Factories
{
    public static class DrinkFactory
    {
        private static IDrinksHandler _drinkConnectionHandler;

        public static IDrinksHandler drinkConnectionHandler
        {
            get
            {
                if (_drinkConnectionHandler == null)
                {
                    _drinkConnectionHandler = new DrinksHandler(new DBConnectionHandler());
                }
                return _drinkConnectionHandler;
            }
        }
    }
}
