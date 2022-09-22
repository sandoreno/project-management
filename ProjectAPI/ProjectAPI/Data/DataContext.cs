using Microsoft.EntityFrameworkCore;
using ProjectAPI.Configuration;
using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Configuration;
using WebAPI.Model;

namespace ProjectAPI.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
           : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<AccessLevel> AccessLevels { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new ProjectConfiguration());
      modelBuilder.ApplyConfiguration(new TaskConfiguration());
      modelBuilder.ApplyConfiguration(new AccessLevelConfiguration());
    }
  }
}
