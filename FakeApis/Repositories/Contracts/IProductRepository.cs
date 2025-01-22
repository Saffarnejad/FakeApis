using FakeApis.Models;

namespace FakeApis.Repositories.Contracts
{
    public interface IProductRepository
    {
        public Task AddAsync(Product product);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product?> GetAsync(int id);
        public Task UpdateAsync(Product product);
    }
}
