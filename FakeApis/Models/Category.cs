using Microsoft.AspNetCore.Identity;

namespace FakeApis.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
