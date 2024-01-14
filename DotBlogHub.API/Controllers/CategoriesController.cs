using DotBlogHub.API.Data;
using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Models.DTO;
using DotBlogHub.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotBlogHub.API.Controllers
{
	//POST: https://localhost:7045/api/categories
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IcategoryRepository categoryRepository;

		public CategoriesController(IcategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
		{
			//Map DTO to Domain Model
			var category = new Category
			{
				Name = request.Name,
				UrlHandle = request.UrlHandle
			};

			await categoryRepository.CreateAsync(category);

			var response = new CategoryDto
			{
				Id = category.Id,
				Name = category.Name,
				UrlHandle = category.UrlHandle
			};


			return Ok(response);
		}

		//Get: https://localhost:7045/api/categories
		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var categories = await categoryRepository.GetAllAsync();

			//Map domain model to DTO

			var response = new List<CategoryDto>();

			foreach (var category in categories)
			{
				response.Add(new CategoryDto
				{
					Id = category.Id,
					Name = category.Name,
					UrlHandle = category.UrlHandle
				});
			}

			return Ok(response);
		}

		//GET: https://localhost:7045/api/categories/{id}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
		{
			var category = await categoryRepository.GetCategoryByIdAsync(id);

			if (category is null)
			{
				return NotFound();
			}

			var response = new CategoryDto
			{
				Id = category.Id,
				Name = category.Name,
				UrlHandle = category.UrlHandle
			};

			return Ok(response);
		}

		//PUT: https://localhost:7045/api/categories/{id}
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> EditCategory([FromRoute]Guid id, [FromBody]UpdateCategoryRequestDto request)
		{
			var category = new Category
			{
				Id = id,
				Name = request.Name,
				UrlHandle = request.UrlHandle
			};

			category = await categoryRepository.UpdateAsync(category);

			if(category is null)
			{
				return NotFound();
			}

			var response = new CategoryDto
			{
				Id = category.Id,
				Name = category.Name,
				UrlHandle = category.UrlHandle
			};

			return Ok(response);
		}

		//DELETE: https://localhost:7045/api/categories/{id}
		[HttpDelete]
		[Route("{id:Guid}")]

		public async Task<IActionResult> DeleteCategory([FromRoute]Guid id)
		{
			var category = await categoryRepository.DeleteAsync(id);

			if(category is null)
			{
				return NotFound();
			}

			var response = new CategoryDto
			{
				Id = id,
				Name = category.Name,
				UrlHandle = category.UrlHandle
			};

			return Ok(response);
		}
	}
}
