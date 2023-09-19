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
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            builder.HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.CustomerContact)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CustomerContactId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(o => o.Address)
            //    .WithMany(a => a.Offers)
            //    .HasForeignKey(o => o.AddressId)
            //    .OnDelete(DeleteBehavior.NoAction);


        }

    }
}
