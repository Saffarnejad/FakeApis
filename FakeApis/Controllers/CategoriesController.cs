using FakeApis.Dtos;
using FakeApis.Helpers;
using FakeApis.Models;
using FakeApis.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly string? _userId;
        //private readonly string? _userName;

        public CategoriesController(ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
            _userId = httpContextAccessor.HttpContext.Items.FirstOrDefault(item => item.Key == "UserId").Value?.ToString();
            //_userName = httpContextAccessor.HttpContext.Items.FirstOrDefault(c => c.Key == "UserName").Value?.ToString();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.GetAllAsync(_userId);
            return Ok(categories.Select(category => category.ToDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetAsync(id, _userId);
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
                Name = categoryDto.Name,
                UserId = _userId
            };

            await _categoryRepository.AddAsync(category);

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category.ToDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetAsync(categoryDto.Id, _userId);
            if (category is null)
            {
                return NotFound();
            }

            category.Name = categoryDto.Name;
            return await _categoryRepository.UpdateAsync(category, _userId) ? NoContent() : Forbid();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetAsync(id, _userId);
            if (category is null)
            {
                return NotFound();
            }

            return await _categoryRepository.DeleteAsync(id, _userId) ? NoContent() : Forbid();
        }
    }
}
