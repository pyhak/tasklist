using Microsoft.EntityFrameworkCore;
using Tasklist.Core.Models;
using Tasklist.Data.configuration;

namespace Tasklist.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions <ApiContext> options) : base(options)  
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }

        [System.Obsolete]
        public DbQuery<Task> Tasks { get; set; }
        
    }
}
