using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoozeStore.Models
{
    public class CustomerViewModel
    {
        [Key]
        public string CustomerID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Required")]
        public string Adress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }

    }
}
