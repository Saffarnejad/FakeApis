using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class AddCategoryDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
