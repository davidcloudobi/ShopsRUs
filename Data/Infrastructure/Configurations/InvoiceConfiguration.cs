using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configurations
{
    public class InvoiceConfiguration: IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
          
            builder.HasKey(owner => owner.Id);

            builder.HasOne(x => x.Customer)
                        .WithMany(x => x.Invoices)
                        .HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.InvoiceProducts)
                       .WithOne(x => x.invoice);
        }
    }
}
