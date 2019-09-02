using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tasklist.Data.configuration
{
    public class TaskMapping
    {
        public TaskMapping(EntityTypeBuilder<Core.Models.Task> entityBuilder)
        {
            entityBuilder.HasKey(g => g.Id);
            entityBuilder.Property(g => g.Id).IsRequired();

            entityBuilder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            entityBuilder.Property(g => g.Status);
        }
    }
}
