namespace EF_modulTask.EntityConfigurations
{
    using EF_modulTask.Entyties;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("GenreId");
            builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(50);
        }
    }
}
