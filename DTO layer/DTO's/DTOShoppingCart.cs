using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_layer.DTO_s
{
    public class DTOShoppingCart
    {
        public string CartID { get; set; }
        public string CustomerID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
