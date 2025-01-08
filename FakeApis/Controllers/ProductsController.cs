using FakeApis.Dtos;
using FakeApis.Helpers;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FakeApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products.Select(product => product.ToDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDto productDto)
        {
            var category = await _categoryRepository.GetAsync(productDto.CategoryId);
            if (category is null)
            {
                return BadRequest("Invalid CategoryId.");
            }

            if (productDto.Images is null || productDto.Images.Count == 0)
            {
                return BadRequest("No images uploaded.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
            await _productRepository.AddAsync(product);

            product.Images = await UploadImages(product.Id, productDto.Images);

            await _productRepository.UpdateAsync(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product.ToDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            if (productDto.CategoryId.HasValue)
            {
                var category = await _categoryRepository.GetAsync(productDto.CategoryId.Value);
                if (category is null)
                {
                    return BadRequest("Invalid CategoryId.");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(productDto.Name) &&
                    string.IsNullOrWhiteSpace(productDto.Description) &&
                    productDto.Price.HasValue &&
                    (productDto.Images is null || productDto.Images.Count == 0))
                {
                    return BadRequest("Enter at least one of the fields.");
                }
            }

            var product = await _productRepository.GetAsync(productDto.Id);
            if (product is null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(productDto.Name))
            {
                product.Name = productDto.Name;
            }

            if (!string.IsNullOrWhiteSpace(productDto.Description))
            {
                product.Description = productDto.Description;
            }

            if (productDto.Price.HasValue && productDto.Price > 0)
            {
                product.Price = productDto.Price.Value;
            }

            if (productDto.CategoryId.HasValue)
            {
                product.CategoryId = productDto.CategoryId.Value;
            }

            if (productDto.Images != null && productDto.Images.Count != 0)
            {
                product.Images = await UploadImages(product.Id, productDto.Images);
            }

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<List<Image>> UploadImages(int productId, List<IFormFile> images)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var productImages = new List<Image>();

            foreach (var image in images)
            {
                var imagePath = Path.Combine(uploadsFolder, image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                var productImage = new Image
                {
                    Url = $"/uploads/{image.FileName}",
                    ProductId = productId
                };

                productImages.Add(productImage);
            }

            return productImages;
        }
    }
}
