using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BoozeStore.Models
{
    public class DrinkViewModel
    {
        [Key]
        public int DrinkID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "Volume")]
        [Required(ErrorMessage = "Required")]
        public int Volume { get; set; }

        [Display(Name = "AlcoholPercentage")]
        [Required(ErrorMessage = "Required")]
        public decimal AlcoholPercentage { get; set; }

        [Display(Name = "AmountStored")]
        [Required(ErrorMessage = "Required")]
        public int AmountStored { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Required")]
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        public string ImageLink { get; set; }
    }
}
