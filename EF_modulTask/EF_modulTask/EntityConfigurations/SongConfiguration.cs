using EF_modulTask.Entyties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_modulTask.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("SongId");
            builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(50);
            builder.Property(p => p.Duration).HasColumnName("Duration").HasColumnType("time");
            builder.Property(p => p.ReleasedDate).HasColumnName("ReleasedDate").HasColumnType("datetime2");
        }
    }
}
