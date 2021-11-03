using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Request
{
   public class CreateInvoiceRequest
    {
        [Required]
        public ICollection<InvoiceProductsRequest> InvoiceProductsRequests { get; set; }
        public bool IsAffiliateStore { get; set; }  
        public bool IsEmployeeStore { get; set; }
        public bool IsECustomerOverTwoYears { get; set; }

    }

    public class InvoiceProductsRequest 
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
