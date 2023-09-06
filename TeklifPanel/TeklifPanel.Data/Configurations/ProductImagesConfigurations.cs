using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Configurations
{
    public class ProductImagesConfigurations : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne(pm => pm.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pm => pm.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
