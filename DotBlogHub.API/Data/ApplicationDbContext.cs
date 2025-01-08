using DotBlogHub.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotBlogHub.API.Data
{
	public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
	{
		public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
