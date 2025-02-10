using FakeApis.Models;

namespace FakeApis.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task AddAsync(Category category);
        public Task<bool> DeleteAsync(int id, string userId);
        public Task<IEnumerable<Category>> GetAllAsync(string userId);
        public Task<Category?> GetAsync(int id, string userId);
        public Task<bool> UpdateAsync(Category category, string userId);
    }
}
