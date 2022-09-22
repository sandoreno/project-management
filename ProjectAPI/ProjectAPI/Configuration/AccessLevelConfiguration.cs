using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Configuration
{
    public class AccessLevelConfiguration : IEntityTypeConfiguration<AccessLevel>
    {
        public void Configure(EntityTypeBuilder<AccessLevel> builder)
        {
            builder.HasKey(x => x.AccessLevelId);
            builder.Property(x => x.AccessLevelId).HasColumnName("accessLevel_id");
            builder.Property(x => x.Role).HasColumnName("role");

        }
    }
}
