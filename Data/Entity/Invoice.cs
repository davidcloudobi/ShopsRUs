using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Invoice : BaseClass
    {
        public string SellersName { get; set; }
        public string CompanyAddress { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
     
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        public int ReferenceNumber { get; set; }

        public ICollection<InvoiceProducts> InvoiceProducts { get; set; }

        public Invoice()
        {
            InvoiceProducts  = new HashSet<InvoiceProducts>();
        }
    }
}
