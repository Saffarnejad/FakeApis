using FakeApis.Data;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FakeApis.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var categoryInDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (categoryInDb != null)
            {
                _db.Categories.Remove(categoryInDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(string userId)
        {
            return await _db.Categories.Where(c => c.UserId == userId || c.UserId == null).ToListAsync();
        }

        public async Task<Category?> GetAsync(int id, string userId)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id && (c.UserId == userId || c.UserId == null));
        }

        public async Task<bool> UpdateAsync(Category category, string userId)
        {
            var categoryInDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == category.Id && c.UserId == userId);
            if (categoryInDb != null)
            {
                categoryInDb.Name = category.Name;
                _db.Categories.Update(categoryInDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
