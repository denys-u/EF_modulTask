namespace EF_modulTask.EntityConfigurations
{
    using EF_modulTask.Entyties;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ArtistId");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnName("DateOfBirth").HasColumnType("datetime2");
            builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(50);
            builder.Property(p => p.InstagramUrl).HasColumnName("InstagramUrl").HasMaxLength(50);
            builder.HasMany(c => c.Songs)
                .WithMany(s => s.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "Supply",
                    j => j
                        .HasOne<Song>()
                        .WithMany()
                        .HasForeignKey("SongId"),
                    j => j
                        .HasOne<Artist>()
                        .WithMany()
                        .HasForeignKey("ArtistId"));
        }
    }
}
