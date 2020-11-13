using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoozeStore.Models
{
    public class ShoppingCartViewModel
    {
        [Key]
        public int CartID { get; set; }

        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "TotalPrice")]
        [Required(ErrorMessage = "Required")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "CreationTime")]
        [Required(ErrorMessage = "Required")]
        public DateTime CreationTime { get; set; }
    }
}
