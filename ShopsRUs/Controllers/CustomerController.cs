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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _CustomerService;

        public CustomerController(ICustomer iCustomerService)
        {
            _CustomerService = iCustomerService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<GlobalResponse<Customer>>> Createcustomer([FromBody] CreateCustomerRequest model)
        {
            var result = await _CustomerService.Createcustomer(model);
            return result.Status ? Ok(result) : BadRequest(result);
        }


        [HttpGet("all")]
        public async Task<ActionResult<GlobalResponse<ICollection<Customer>>>> GetAllCustomers()
        {
            var result = await _CustomerService.GetAllCustomers();
            return result.Status ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GlobalResponse<Customer>>> GetCustomerById([FromRoute] int id)
        {
            var result = await _CustomerService.GetCustomerById(id);
            return result.Status ? Ok(result) : BadRequest(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<GlobalResponse<Customer>>> GetCustomerById([FromRoute] string name)
        {
            var result = await _CustomerService.GetCustomerByName(name);
            return result.Status ? Ok(result) : BadRequest(result);
        }
    }
}
