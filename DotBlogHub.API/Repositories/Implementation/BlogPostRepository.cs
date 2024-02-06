using DotBlogHub.API.Data;
using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Repositories.Interface;

namespace DotBlogHub.API.Repositories.Implementation
{
	public class BlogPostRepository: IBlogPostRepository
	{
		private readonly ApplicationDbContext dbContext;

		public BlogPostRepository(ApplicationDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		public async Task<BlogPost> CreateAsync(BlogPost blogPost)
		{
			await dbContext.BlogPosts.AddAsync(blogPost);
			await dbContext.SaveChangesAsync();

			return blogPost;
		}
    }
}
