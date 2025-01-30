using FakeApis.Models;

namespace FakeApis.Repositories.Contracts
{
    public interface IImageRepository
    {
        public Task DeleteAsync(int id);
        public Task<Image?> GetAsync(int id);
    }
}
