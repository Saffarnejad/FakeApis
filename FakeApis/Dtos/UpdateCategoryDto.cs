using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
