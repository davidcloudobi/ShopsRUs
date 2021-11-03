using Data.Entity;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Service.Helper;
using Service.Interface;
using Service.Request;
using Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class InvoiceService : IInvoice
    {
        public ApplicationDbContext DbContext { get; set; }

        public InvoiceService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<GlobalResponse<InvoiceTotalAmountResponse>> GetTotalInvoiceAmount(CreateInvoiceRequest model)
        {
            List<InvoiceTotalHelper> productsHelper = new List<InvoiceTotalHelper>();

            foreach (var item in model.InvoiceProductsRequests)
            {
                var product = await DbContext.Products.SingleOrDefaultAsync(x => x.Id == item.ProductId);

                if (product is null)
                {
                    return new GlobalResponse<InvoiceTotalAmountResponse>
                    {
                        Message = "Invalid product Id",
                        Status = false,
                        Data = null
                    };
                }
                productsHelper.Add(new InvoiceTotalHelper { Price = product.Price * item.   Count, IsGroceries = product.IsGrocery });

            }
            var discountEligibleProductPrice = productsHelper.Where(x => x.IsGroceries == false).Sum(x => x.Price);
            var discountNonEligibleProductPrice = productsHelper.Where(x => x.IsGroceries == true).Sum(x => x.Price);
         

            if (model.IsAffiliateStore)
            {
                
                var discountedPrice = discountEligibleProductPrice - (discountEligibleProductPrice * 10 /100);
               var totalPrice = discountNonEligibleProductPrice + discountedPrice;
                var discountPerHundereds = (totalPrice / 100) * 5;
                var finalResult = totalPrice - discountPerHundereds;
                return new GlobalResponse<InvoiceTotalAmountResponse>
                {
                    Message = "Successful",
                    Status = false,
                    Data = new InvoiceTotalAmountResponse { TotalAmount = finalResult }
                };
            }

            if (model.IsEmployeeStore)
            {
        
                var discountedPrice = discountEligibleProductPrice - (discountEligibleProductPrice * 30 / 100);
                var totalPrice = discountNonEligibleProductPrice + discountedPrice;
                var discountPerHundereds = (totalPrice / 100) * 5;
                var finalResult = totalPrice - discountPerHundereds;
                return new GlobalResponse<InvoiceTotalAmountResponse>
                {
                    Message = "Successful",
                    Status = false,
                    Data = new InvoiceTotalAmountResponse { TotalAmount = finalResult }
                };
            }

            if (model.IsECustomerOverTwoYears)
            {

                var discountedPrice = discountEligibleProductPrice - (discountEligibleProductPrice * 5 / 100);
                var totalPrice = discountNonEligibleProductPrice + discountedPrice;
                var discountPerHundereds = (totalPrice / 100) * 5;
                var finalResult = totalPrice - discountPerHundereds;
                return new GlobalResponse<InvoiceTotalAmountResponse>
                {
                    Message = "Successful",
                    Status = false,
                    Data = new InvoiceTotalAmountResponse { TotalAmount = finalResult }
                };
            }


            else
            {
            
                var totalPrice = discountNonEligibleProductPrice + discountEligibleProductPrice;
                var discountPerHundereds = (totalPrice / 100) * 5;
                var finalResult = totalPrice - discountPerHundereds;
                return new GlobalResponse<InvoiceTotalAmountResponse>
                {
                    Message = "Successful",
                    Status = false,
                    Data = new InvoiceTotalAmountResponse { TotalAmount = finalResult }
                };
            }

        }
    }
}
