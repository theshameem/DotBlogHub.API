using DotBlogHub.API.Data;
using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

		public async Task<IEnumerable<BlogPost>> GetAllBlogsAsync()
		{
			return await dbContext.BlogPosts.Include(x => x.Categories).ToListAsync();
		}

		public async Task<BlogPost?> GetBlogPostByIdAsync(Guid id)
		{
			return await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
