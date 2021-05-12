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
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(50);

            builder.HasData(new List<Genre>()
            {
                new Genre() {Id = 1, Title = "Pop"},
                new Genre() {Id = 2, Title = "Hip-hop"},
                new Genre() {Id = 3, Title = "Country"},
                new Genre() {Id = 4, Title = "Rap"},
                new Genre() {Id = 5, Title = "Rock"}
            });
        }
    }
}
