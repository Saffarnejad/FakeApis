using FakeApis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeApis.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Name).HasMaxLength(20);

            var categories = new List<Category>
            {
                new() { Id = 1, Name = "Appliances" },
                new() { Id = 2, Name = "Clothing" },
                new() { Id = 3, Name = "Food" },
                new() { Id = 4, Name = "Furniture" },
                new() { Id = 5, Name = "Phones" }
            };

            builder.HasData(categories);
        }
    }
}
