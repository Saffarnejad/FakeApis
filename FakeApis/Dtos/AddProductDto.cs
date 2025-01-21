using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class AddProductDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
