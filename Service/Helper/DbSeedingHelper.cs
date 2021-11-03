using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    public class DbSeedingHelper
    {
        

        public static IEnumerable<Products> SeedProducts()
        {
            var products = new List<Products>()
            {
                new Products()
                {
                    Name = "Books",
                    IsGrocery = false,
                    Price =500
                },
                 new Products()
                {
                    Name = "Orange",
                    IsGrocery = true,
                    Price =300
                },
                    new Products()
                {
                    Name = "Milk",
                    IsGrocery = true,
                    Price =1200
                },
                       new Products()
                {
                    Name = "Eggs",
                    IsGrocery = false,
                    Price =3500
                },
                          new Products()
                {
                    Name = "Phone",
                    IsGrocery = false,
                    Price =25000
                },
                             new Products()
                {
                    Name = "Cloths",
                    IsGrocery = false,
                    Price =3000
                },
            };
            return products;


        }

  
    }
}
