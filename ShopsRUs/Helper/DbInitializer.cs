using Data.Infrastructure;
using Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;

namespace ShopsRUs.Helper
{
    public class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context, IServiceProvider services)
        {
            // Get a logger
         
           var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            // Make sure the database is created
            // We already did this in the previous step
            context.Database.EnsureCreated();

            try
            {
                if (context.Products.Any())
                {
                    logger.Debug("The database was already seeded");
                    return;
                }
                //logger.Debug("Start seeding the database.");
                var businessTypes = DbSeedingHelper.SeedProducts();
                context.Products.AddRange(businessTypes);
                
                context.SaveChanges();
               // logger.Debug("Finished seeding the database.");
            }
            catch (Exception )
            {
               // logger.Error(e, "Error occurred when seeding");
            }

        }
    }
}
