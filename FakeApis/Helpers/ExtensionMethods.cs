using FakeApis.Dtos;
using FakeApis.Models;

namespace FakeApis.Helpers
{
    public static class ExtensionMethods
    {
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static ProductDto ToDto(this Product product)
        {
            var baseUrl = UrlHelper.GetBaseUrl();
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category.Name,
                Images = product.Images.Select(image => $"{baseUrl}/uploads/{image.Name}").ToList()
            };
        }
    }
}
