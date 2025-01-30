using FakeApis.Data;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FakeApis.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _db;

        public ImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task DeleteAsync(int id)
        {
            var imageInDb = await _db.Images.FirstOrDefaultAsync(i => i.Id == id);
            if (imageInDb != null)
            {
                _db.Images.Remove(imageInDb);
            }
        }

        public async Task<Image?> GetAsync(int id)
        {
            return await _db.Images.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
