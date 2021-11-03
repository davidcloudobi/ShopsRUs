using Data;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
    public class DiscountsService : IDiscounts
    {
        public ApplicationDbContext DbContext { get; set; }

        public DiscountsService(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }
        public async Task<GlobalResponse<Discounts>> CreateDiscount(DiscountsRequest model)
        {
            var check = await DbContext.Discounts.SingleOrDefaultAsync(x => x.DiscountType == model.DiscountType);
            if (check is not null)
            {
                return new GlobalResponse<Discounts>
                {
                    Message = "type already taken",
                    Status = false,
                    Data = null
                };
            }
            var data = new Discounts
            {
                PercentageProperty = model.PercentageProperty,
                DateCreated = DateTime.Now,
                DiscountType = model.DiscountType
            };

            await DbContext.Discounts.AddAsync(data);
            var result = await DbContext.SaveChangesAsync();

            return
                result > 0 ?
                new GlobalResponse<Discounts>
                {
                    Message = "Successful",
                    Status = true,
                    Data = data
                }
                :
            new GlobalResponse<Discounts>
            {
                Message = "Error occured, please try again",
                Status = false,
                Data = null
            };
        }

        public async Task<GlobalResponse<ICollection<Discounts>>> GetAllDiscount()
        {
            var datas = await DbContext.Discounts.ToListAsync();

            return new GlobalResponse<ICollection<Discounts>>
            {
                Message = "Successsful",
                Status = true,
                Data = datas
            };

        }

        public async Task<GlobalResponse<Discounts>> GetDiscountByType(string type)
        {
            var data = await DbContext.Discounts.SingleOrDefaultAsync(x => x.DiscountType == type);

            return data is not null ? new GlobalResponse<Discounts>
            {
                Message = "Successsful",
                Status = true,
                Data = data
            }
            :
              new GlobalResponse<Discounts>
              {
                  Message = "Data not found, please try again",
                  Status = false,
                  Data = null
              };
        }
    }
}
