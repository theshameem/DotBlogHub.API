using DotBlogHub.API.Data;
using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Repositories.Interface;

namespace DotBlogHub.API.Repositories.Implementation
{
	public class CategoryRepository : IcategoryRepository
	{
		private readonly ApplicationDbContext dbContext;

		public CategoryRepository(ApplicationDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<Category> CreateAsync(Category category)
		{
			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();

			return category;
		}
	}
}
