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
    public interface ICustomer
    {
        Task<GlobalResponse<Customer>> Createcustomer(CreateCustomerRequest model);
        Task<GlobalResponse<Customer>> GetCustomerById(int id);
        Task<GlobalResponse<Customer>> GetCustomerByName(string name);
        Task<GlobalResponse<ICollection<Customer>>> GetAllCustomers();
    }
}
