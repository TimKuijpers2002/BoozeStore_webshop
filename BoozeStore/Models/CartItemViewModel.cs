using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoozeStore.Models
{
    public class CartItemViewModel
    {
        [Key]
        public int CartID { get; set; }

        [Key]
        public int DrinkID { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }
    }
}
