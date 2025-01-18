using FakeApis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeApis.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name).HasMaxLength(50);

            var products = new List<Product>
            {
                new() { Id = 1, Name = "Microwave", Description = "A microwave oven or simply microwave is an electric oven that heats and cooks food by exposing it to electromagnetic radiation in the microwave frequency range. This induces polar molecules in the food to rotate and produce thermal energy in a process known as dielectric heating.", Price = 62.96m, CategoryId = 1 },
                new() { Id = 2, Name = "Refrigerator", Description = "A refrigerator, commonly shortened to fridge, is a commercial and home appliance consisting of a thermally insulated compartment and a heat pump that transfers heat from its inside to its external environment so that its inside is cooled to a temperature below the room temperature.", Price = 359.99m, CategoryId = 1 },
                new() { Id = 3, Name = "Hoodie", Description = "MADE FOR COMFORT AND WARM: Sherpa fleece lined hoodies for men, our men's hoodie is made with warm and comfortable fleece sherpa polyester and cotton. Fuzzy fluffy sherpa fleece lining, added warmth and comfort, helps block out the cold.", Price = 39.98m, CategoryId = 2 },
                new() { Id = 4, Name = "Nutella Cocoa with Breadsticks", Description = "NUTELLA HAZELNUT SNACK CUP: Discover the Original Hazelnut Spread in a fun and convenient snack cup with breadsticks that's perfect anytime, anywhere. Dip into wow with this 24-pack of Nutella & GO!", Price = 10.38m, CategoryId = 3 },
            };

            builder.HasData(products);
        }
    }
}
