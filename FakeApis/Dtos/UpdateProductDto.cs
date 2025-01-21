using System.ComponentModel.DataAnnotations;

namespace FakeApis.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
