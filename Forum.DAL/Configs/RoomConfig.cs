using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DAL.Configs
{
    internal class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(t => t.RoomName)
                .HasMaxLength(50)
                .IsRequired(true);
            builder.HasMany(t => t.Posts)
                .WithOne(p => p.Room)
                .HasForeignKey(f => f.ThreadId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
