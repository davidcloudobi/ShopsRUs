using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
  public  class InvoiceProducts: BaseClass
    {
        public int ProductsId { get; set; }
        public Products Products { get; set; }
            
        public DateTime CreateOn { get; set; }

        public decimal Price { get; set; }

        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }

    }
}
    