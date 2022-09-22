using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Configuration
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // первичный ключ
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.FirstName).HasColumnName("first_name").IsRequired().HasMaxLength(30);
        builder.Property(x => x.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(30);
        builder.Property(x => x.Login).HasColumnName("login").IsRequired().HasMaxLength(30);
        builder.Property(x => x.Password).HasColumnName("password").IsRequired().HasMaxLength(30);
        builder.HasOne(x => x.AccessLevel).WithMany(x => x.Users).HasForeignKey(x => x.AccessLevelId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.AccessLevelId).HasColumnName("accessLevel_id");
    }
  }
}
