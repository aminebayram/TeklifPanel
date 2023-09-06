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
    public class LogConfigurations : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
           builder.HasOne(l => l.Company)
                .WithMany(c => c.Logs)
                .HasForeignKey(l => l.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
