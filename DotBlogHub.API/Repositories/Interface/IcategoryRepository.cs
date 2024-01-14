using DotBlogHub.API.Models.Domain;

namespace DotBlogHub.API.Repositories.Interface
{
	public interface IcategoryRepository
	{
		Task<Category> CreateAsync(Category category);
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category?> GetCategoryByIdAsync(Guid id);
		Task<Category?> UpdateAsync(Category category);
		Task<Category?> DeleteAsync(Guid id);
	}
}
