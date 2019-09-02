using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasklist.Core.Models;

namespace Tasklist.Data.configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
       
    public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Description)
                .IsRequired()
                .IsUnicode(true);
            builder.Property(g => g.Status);       
        }
    }
}
