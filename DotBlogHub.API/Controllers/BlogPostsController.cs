using DotBlogHub.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotBlogHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostsController : ControllerBase
	{
		//POST: {apiBaseUrl}/api/blogposts 
		[HttpPost]
		public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto request)
		{
			var blogPost = new CreateBlogPostRequestDto
			{
				Title = request.Title,
				Author = request.Author,
				PublishedDate = request.PublishedDate,
				IsVisible = request.IsVisible,
				ShortDescription = request.ShortDescription,
				Content = request.Content,
				UrlHandle = request.UrlHandle,
				FeatureImageUrl = request.FeatureImageUrl,
			};

		//	public string Title { get; set; }
		//public string ShortDescription { get; set; }
		//public string Content { get; set; }
		//public string FeatureImageUrl { get; set; }
		//public string UrlHandle { get; set; }
		//public DateTime PublishedDate { get; set; }
		//public string Author { get; set; }
		//public bool IsVisible { get; set; }
	}
	}
}
