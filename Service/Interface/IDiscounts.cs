using Data;
using Service.Request;
using Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDiscounts
    {
        Task<GlobalResponse<Discounts>> CreateDiscount(DiscountsRequest model);
      
        Task<GlobalResponse<Discounts>> GetDiscountByType(string type);
        Task<GlobalResponse<ICollection<Discounts>>> GetAllDiscount();

    }
}
