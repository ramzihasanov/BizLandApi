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
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        void IEntityTypeConfiguration<Slider>.Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Desc).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ButtonText).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ButtonUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.VideoUrl).IsRequired().HasMaxLength(200);
        }
    }
}
