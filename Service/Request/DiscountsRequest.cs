using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Request
{
  public  class DiscountsRequest
    {
        [Required]
        public double PercentageProperty { get; set; }
        [Required]
        public string DiscountType { get; set; }
     
    }
}
