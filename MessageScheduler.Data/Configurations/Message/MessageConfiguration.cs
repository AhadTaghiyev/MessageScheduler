
using x=MessageScheduler.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Data.Configurations.Message
{
    public class MessageConfiguration : IEntityTypeConfiguration<x.Message>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<x.Message> builder)
        {
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x=>x.To).IsRequired();
        }
    }
}
