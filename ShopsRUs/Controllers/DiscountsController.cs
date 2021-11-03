using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Request;
using Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {

        private readonly IDiscounts _discountsService;

        public DiscountsController(IDiscounts discountsService)
        {
            _discountsService = discountsService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<GlobalResponse<Discounts>>> CreateDiscount([FromBody] DiscountsRequest model)
        {
            var result = await _discountsService.CreateDiscount(model);
            return result.Status ? Ok(result) : BadRequest(result);
        }


        [HttpGet("all")]
        public async Task<ActionResult<GlobalResponse<ICollection<Discounts>>>> GetAllDiscount()
        {
            var result = await _discountsService.GetAllDiscount();
            return result.Status ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{type}")]
        public async Task<ActionResult<GlobalResponse<Discounts>>> GetAllDiscount([FromRoute] string type)
        {
            var result = await _discountsService.GetDiscountByType(type);
            return result.Status ? Ok(result) : BadRequest(result);
        }
    }
}
