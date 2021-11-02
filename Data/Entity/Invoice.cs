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
        public string CompanyRegistrationNumber { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        //public string BuyerName { get; set; }
        //public string BuyerAddress { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ReferenceNumber { get; set; }
    }
}
