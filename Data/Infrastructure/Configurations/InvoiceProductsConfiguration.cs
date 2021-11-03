using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure.Configurations
{
    public class InvoiceProductsConfiguration : IEntityTypeConfiguration<InvoiceProducts>
    {
        public void Configure(EntityTypeBuilder<InvoiceProducts> builder)
        {

            builder.HasKey(owner => owner.Id);

            builder.HasOne(x => x.invoice)
                        .WithMany(x => x.InvoiceProducts)
                        .HasForeignKey(x => x.InvoiceId);


            builder.HasOne(x => x.Products)
                        .WithMany(x => x.InvoiceProducts)
                        .HasForeignKey(x => x.ProductsId);
        }
    }
}