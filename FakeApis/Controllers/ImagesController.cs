using FakeApis.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _imageRepository.GetAsync(id);
            if (image is null)
            {
                return NotFound();
            }

            await _imageRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
