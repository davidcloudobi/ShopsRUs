using Service.Request;
using Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IInvoice
    {
        Task<GlobalResponse<InvoiceTotalAmountResponse>> GetTotalInvoiceAmount (CreateInvoiceRequest model);

    }
}
