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
    public class CustomerService : ICustomer
    {
        public ApplicationDbContext  DbContext{ get; set; }

        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

        public async Task<GlobalResponse<Customer>> Createcustomer(CreateCustomerRequest model)
        {
            var check = await DbContext.Customers.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (check is not null)
            {
                return new GlobalResponse<Customer>
                {
                    Message = "Name already taken",
                    Status = false,
                    Data = null
                };
            }
            var data = new Customer
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Phonenumber = model.Phonenumber,
                Email = model.Email,
                Address = model.Address,
                DateCreated = DateTime.Now
            };

            await DbContext.Customers.AddAsync(data);
          var result = await   DbContext.SaveChangesAsync();

            return
                result > 0 ? 
                new GlobalResponse<Customer>
            {
                Message = "Successful",
                Status = true,
                Data = data
            } 
                :
            new GlobalResponse<Customer>
            {
                Message = "Error occured, please try again",
                Status = false,
                Data = null
            };
        }

        public async Task<GlobalResponse<ICollection<Customer>>> GetAllCustomers()
        {
            var datas = await DbContext.Customers.ToListAsync();
           
                return new GlobalResponse<ICollection<Customer>>
                {
                    Message = "Successsful",
                    Status = true,
                    Data = datas
                };
            
        }

        public async Task<GlobalResponse<Customer>> GetCustomerById(int id)
        {
            var data = await DbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);

            return data is not null ?  new GlobalResponse<Customer>
            {
                Message = "Successsful",
                Status = true,
                Data = data
            } 
            :
              new GlobalResponse<Customer>
              {
                  Message = "Data not found, please try again",
                  Status = false,
                  Data = null
              };
        }
    

        public async Task<GlobalResponse<Customer>> GetCustomerByName(string name)
        {
        var data = await DbContext.Customers.SingleOrDefaultAsync(x => x.Name == name );

        return data is not null ? new GlobalResponse<Customer>
        {
            Message = "Successsful",
            Status = true,
            Data = data
        }
        :
          new GlobalResponse<Customer>
          {
              Message = "Data not found, please try again",
              Status = false,
              Data = null
          };
    }
}
    }

