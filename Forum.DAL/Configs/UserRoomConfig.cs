using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DAL.Configs
{
    internal class UserRoomConfig : IEntityTypeConfiguration<UserRoom>
    {
        public void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.HasKey(key => new { key.UserId, key.RoomId} );
            builder.HasAlternateKey(key => key.Id);
            builder.HasOne(p => p.User)
                .WithMany(u => u.UserRooms)
                .HasForeignKey(f => f.UserId)
                .IsRequired();
            builder.HasOne(p => p.Room)
                .WithMany(t => t.UserRooms)
                .HasForeignKey(f => f.RoomId)
                .IsRequired();
        }
    }
}
