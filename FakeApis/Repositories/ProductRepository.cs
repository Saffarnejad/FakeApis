using FakeApis.Data;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FakeApis.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productInDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productInDb != null)
            {
                _db.Products.Remove(productInDb);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            var productInDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productInDb != null)
            {
                return productInDb;
            }
            return new Product();
        }

        public async Task UpdateAsync(Product product)
        {
            var productInDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productInDb != null)
            {
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Price = product.Price;
                productInDb.ImageUrl = product.ImageUrl;
                productInDb.CategoryId = product.CategoryId;
                _db.Products.Update(productInDb);
                await _db.SaveChangesAsync();
            }
        }
    }
}
