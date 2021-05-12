namespace EF_modulTask.EntityConfigurations
{
    using EF_modulTask.Entyties;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("SongId");
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(50);
            builder.Property(p => p.Duration).IsRequired().HasColumnName("Duration").HasColumnType("time");
            builder.Property(p => p.ReleasedDate).IsRequired().HasColumnName("ReleasedDate").HasColumnType("date");
            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Songs)
                .HasForeignKey(d => d.GenreID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
