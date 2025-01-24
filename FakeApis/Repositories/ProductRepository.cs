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
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            var productInDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productInDb != null)
            {
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Price = product.Price;
                productInDb.CategoryId = product.CategoryId;
                productInDb.Images = product.Images;
                _db.Products.Update(productInDb);
                await _db.SaveChangesAsync();
            }
        }
    }
}
