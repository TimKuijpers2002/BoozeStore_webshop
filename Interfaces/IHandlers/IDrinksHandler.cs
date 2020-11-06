using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IDrinksHandler
    {
        void CreateDrink(DTODrink D1);
        List<DTODrink> GetDrinks();
        void UpdateDrink(DTODrink U1);
        void DeleteDrink(int ID);
    }
}
