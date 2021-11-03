using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Request
{
   public class CreateCustomerRequest
    {
        [Required]
        public string Name { get; set; }
     
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
       
        public int Phonenumber { get; set; }
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
