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
    }
}
