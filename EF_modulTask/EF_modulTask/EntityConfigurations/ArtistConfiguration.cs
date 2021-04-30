using EF_modulTask.Entyties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_modulTask.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("datetime2");
            builder.Property(p => p.Phone).IsRequired().HasColumnName("Phone").HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasColumnName("Email").HasMaxLength(50);
            builder.Property(p => p.InstagramUrl).IsRequired().HasColumnName("InstagramUrl").HasMaxLength(50);
        }
    }
}
