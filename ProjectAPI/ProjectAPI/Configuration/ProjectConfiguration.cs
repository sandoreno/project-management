using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Configuration
{
    public class ProjectConfiguration: IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // первичный ключ
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.ProjectId).HasColumnName("project_id");
            // настрока внешнего ключа
            builder.HasOne(x => x.User).WithMany(x => x.Projects).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.BeginDate).HasColumnName("begin_date");
            builder.Property(x => x.EndDate).HasColumnName("end_date");
            builder.Property(x => x.Deleted).HasColumnName("deleted").HasDefaultValue(false);
        }
    }
}