using FakeApis.Models;

namespace FakeApis.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task AddAsync(Category category);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> GetAsync(int id);
        public Task UpdateAsync(Category category);
    }
}
