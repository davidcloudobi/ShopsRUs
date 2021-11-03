using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Data.Entity
{
  public  class Products: BaseClass
    {
        public string Name { get; set; }    
        public bool IsGrocery{ get; set; }

        public decimal Price { get; set; }

        public ICollection<InvoiceProducts> InvoiceProducts { get; set; }

        public Products()
        {
            InvoiceProducts = new HashSet<InvoiceProducts>();
        }
    }
}
