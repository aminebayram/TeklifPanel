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
    public class CustomerContactConfigurations : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.HasOne(cc => cc.Customer)
                .WithMany(c => c.CustomerContacts)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cc => cc.Company)
                .WithMany(c => c.CustomerContacts)
                .HasForeignKey(cc => cc.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
