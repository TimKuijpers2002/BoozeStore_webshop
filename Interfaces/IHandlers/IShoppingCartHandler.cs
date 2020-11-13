using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IShoppingCartHandler
    {
        void CreateShoppingCart(DTOShoppingCart C1);
        List<DTOShoppingCart> GetShoppingCarts();
        void UpdateShoppingCart(DTOShoppingCart UC1);
        void DeleteShoppingCart(int ID);
    }
}
