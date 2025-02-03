using FakeApis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeApis.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(image => image.Name).HasMaxLength(50);

            var images = new List<Image>
            {
                new() { Id = 1, Name = "image1.jpg", ProductId = 1 },
                new() { Id = 2, Name = "image2.jpg", ProductId = 1 },
                new() { Id = 3, Name = "image3.jpg", ProductId = 2 },
                new() { Id = 4, Name = "image4.jpg", ProductId = 3 },
                new() { Id = 5, Name = "image5.jpg", ProductId = 3 },
                new() { Id = 6, Name = "image6.jpg", ProductId = 3 },
                new() { Id = 7, Name = "image7.jpg", ProductId = 4 },
                new() { Id = 8, Name = "image8.jpg", ProductId = 4 },
            };

            builder.HasData(images);
        }
    }
}
