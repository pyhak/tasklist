using Microsoft.EntityFrameworkCore;
using ToDo2.Core.Models;
using ToDo2.Data.configuration;

namespace ToDo2.Data
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
