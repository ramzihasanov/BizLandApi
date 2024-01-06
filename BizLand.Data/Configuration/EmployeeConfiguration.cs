using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLand.Core.Entities;

namespace BizLand.Data.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(x => x.InstaUrl)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.TwitUrl)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(x => x.FaceUrl)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(x => x.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(x => x.LnedinUrl)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasOne(x => x.Profession).WithMany(p => p.Employees);

        }
    
    }
}
