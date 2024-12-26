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

        public async Task DeleteAsync(int id)
        {
            var categoryInDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryInDb != null)
            {
                _db.Categories.Remove(categoryInDb);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            var categoryInDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryInDb != null)
            {
                return categoryInDb;
            }
            return new Category();
        }

        public async Task UpdateAsync(Category category)
        {
            var categoryInDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (categoryInDb != null)
            {
                categoryInDb.Name = category.Name;
                _db.Categories.Update(categoryInDb);
                await _db.SaveChangesAsync();
            }
        }
    }
}
