using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface ICartItemsHandler
    {
        void CreateOrder(DTOOrder O1);
        List<DTOOrder> GetOrders();
        void UpdateOrder(DTOOrder UO1);
        void DeleteOrder(string ID);
    }
}
