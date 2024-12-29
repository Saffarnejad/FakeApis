using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
