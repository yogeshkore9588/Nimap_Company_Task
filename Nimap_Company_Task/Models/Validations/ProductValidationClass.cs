using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap_Company_Task.Models.Validations
{
    public class ProductValidationClass
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public Nullable<int> CategoryID { get; set; }
    }
}