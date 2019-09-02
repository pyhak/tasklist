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
            new TaskMapping(modelBuilder.Entity<Task>());
        }

        [System.Obsolete]
        public DbQuery<Task> Tasks { get; set; }
        
    }
}
