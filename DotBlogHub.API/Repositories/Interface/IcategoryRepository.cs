using DotBlogHub.API.Models.Domain;

namespace DotBlogHub.API.Repositories.Interface
{
	public interface IcategoryRepository
	{
		Task<Category> CreateAsync(Category category);
	}
}
