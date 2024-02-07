using DotBlogHub.API.Models.Domain;

namespace DotBlogHub.API.Repositories.Interface
{
	public interface IBlogPostRepository
	{
		Task<BlogPost> CreateAsync(BlogPost blogPost);
		Task<IEnumerable<BlogPost>> GetAllBlogsAsync(); 
	}
}
