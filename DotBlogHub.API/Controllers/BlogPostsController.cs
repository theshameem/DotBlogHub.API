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
		private readonly IcategoryRepository categoryRepository;

		public BlogPostsController(IBlogPostRepository blogPostRepository, IcategoryRepository categoryRepository)
        {
			this.blogPostRepository = blogPostRepository;
			this.categoryRepository = categoryRepository;
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
				Categories = new List<Category>()
			};

			foreach(var categoryGuid in request.Categories)
			{
				var existingCategory = await categoryRepository.GetCategoryByIdAsync(categoryGuid);

				if(existingCategory is not null)
				{
					blogPost.Categories.Add(existingCategory);
				}
			}

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
				Categories = blogPost.Categories.Select(x => new CategoryDto { Id = x.Id, Name = x.Name, UrlHandle = x.UrlHandle }).ToList()
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
					Categories = blog.Categories.Select(x => new CategoryDto { Id = x.Id, Name = x.Name, UrlHandle = x.UrlHandle }).ToList()
				});
			}

			return Ok(response);
		}
	}
}
