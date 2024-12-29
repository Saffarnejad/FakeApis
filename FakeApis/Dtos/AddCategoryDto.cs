using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class AddCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
