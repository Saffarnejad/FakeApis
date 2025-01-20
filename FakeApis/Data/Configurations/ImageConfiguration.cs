using FakeApis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeApis.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(image => image.Url).HasMaxLength(2048);

            var images = new List<Image>
            {
                new() { Id = 1, Url = "https://m.media-amazon.com/images/I/81gP22+jCVL._AC_SX679_.jpg", ProductId = 1 },
                new() { Id = 2, Url = "https://m.media-amazon.com/images/I/81FiOrqdYtL._AC_SX679_.jpg", ProductId = 1 },
                new() { Id = 3, Url = "https://m.media-amazon.com/images/I/611+ApROVpL._AC_SX342_SY445_.jpg", ProductId = 2 },
                new() { Id = 4, Url = "https://m.media-amazon.com/images/I/71YxVwUVevL._AC_SY550_.jpg", ProductId = 3 },
                new() { Id = 5, Url = "https://m.media-amazon.com/images/I/81sIVuoPJYL._AC_SY550_.jpg", ProductId = 3 },
                new() { Id = 6, Url = "https://m.media-amazon.com/images/I/81gjPXnTs8L._AC_SY550_.jpg", ProductId = 3 },
                new() { Id = 7, Url = "https://m.media-amazon.com/images/I/81rCVMMNsiL._SX679_.jpg", ProductId = 4 },
                new() { Id = 8, Url = "https://m.media-amazon.com/images/I/81nUwEwQlqL._SX679_.jpg", ProductId = 4 },
            };

            builder.HasData(images);
        }
    }
}
