using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DAL.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(u => u.DateOfBirth)
                .IsRequired(false);
            builder.Property(u => u.UserPhotoPath)
                .IsRequired(false)
                .HasMaxLength(200);
        }
    }
}
