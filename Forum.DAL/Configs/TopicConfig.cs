using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DAL.Configs
{
    internal class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(t => t.TopicName)
                .HasMaxLength(50);
            builder.HasMany(t => t.Rooms)
                .WithOne(p => p.Topic)
                .HasForeignKey(f => f.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
