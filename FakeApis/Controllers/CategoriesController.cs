using FakeApis.Dtos;
using FakeApis.Helpers;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FakeApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories.Select(category => category.ToDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryRepository.AddAsync(category);

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category.ToDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetAsync(categoryDto.Id);
            if (category is null)
            {
                return NotFound();
            }

            category.Name = categoryDto.Name;
            await _categoryRepository.UpdateAsync(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        private async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
