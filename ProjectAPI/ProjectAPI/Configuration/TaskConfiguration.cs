using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            // первичный ключ
            builder.HasKey(x => x.TasksId);
            builder.Property(x => x.TasksId).HasColumnName("task_id");
            // настрока внешнего ключа
            builder.HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.ProjectId).HasColumnName("project_id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Start).HasColumnName("begin_date");
            builder.Property(x => x.End).HasColumnName("end_date");
            builder.Property(x => x.Progress).HasColumnName("progress");
            builder.Property(x => x.Dependecies).HasColumnName("dependecies");
            builder.Property(x => x.Deleted).HasColumnName("deleted").HasDefaultValue(false);

        }
    }
}
