using BizLand.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Configuration
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {


        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

        }
    }
}
