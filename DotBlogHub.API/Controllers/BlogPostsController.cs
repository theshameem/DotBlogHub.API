using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Models.DTO;
using DotBlogHub.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotBlogHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostsController : ControllerBase
	{
		private readonly IBlogPostRepository blogPostRepository;

		public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
			this.blogPostRepository = blogPostRepository;
		}

        //POST: {apiBaseUrl}/api/blogposts 
        [HttpPost]
		public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
		{
			var blogPost = new BlogPost
			{
				Title = request.Title,
				Author = request.Author,
				PublishedDate = request.PublishedDate,
				IsVisible = request.IsVisible,
				ShortDescription = request.ShortDescription,
				Content = request.Content,
				UrlHandle = request.UrlHandle,
				FeaturedImageUrl = request.FeaturedImageUrl,
			};

			blogPost = await blogPostRepository.CreateAsync(blogPost);

			var response = new BlogPostDto
			{
				Id = blogPost.Id,
				Title = blogPost.Title,
				Author = blogPost.Author,
				PublishedDate = blogPost.PublishedDate,
				IsVisible = blogPost.IsVisible,
				ShortDescription = blogPost.ShortDescription,
				Content = blogPost.Content,
				UrlHandle = blogPost.UrlHandle,
				FeaturedImageUrl = blogPost.FeaturedImageUrl,
			};

			return Ok(response);
		}

		//GET: {apiBaseUrl}/api/blogposts
		[HttpGet]
		public async Task<IActionResult> GetBlogPostsList()
		{
			var blogList = await blogPostRepository.GetAllBlogsAsync();

			var response = new List<BlogPostDto>();

			foreach(var blog in blogList)
			{
				response.Add(new BlogPostDto
				{
					Id = blog.Id, 
					Title = blog.Title,
					Author = blog.Author,
					PublishedDate = blog.PublishedDate,
					ShortDescription = blog.ShortDescription,
					Content = blog.Content,
					UrlHandle = blog.UrlHandle,
					FeaturedImageUrl = blog.FeaturedImageUrl,
					IsVisible = blog.IsVisible,
				});
			}

			return Ok(response);
		}
	}
}
