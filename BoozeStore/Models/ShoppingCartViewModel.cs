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
        public string CartID { get; set; }

        [Key]
        public string CustomerID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "TotalPrice")]
        [Required(ErrorMessage = "Required")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "CreationTime")]
        [Required(ErrorMessage = "Required")]

        private DateTime? date;

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime CreationTime
        {
            get { return date ?? DateTime.Today; }
            set { date = value; }
        }
    }
}
