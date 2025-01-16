using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
