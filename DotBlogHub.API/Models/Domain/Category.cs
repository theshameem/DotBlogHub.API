﻿namespace DotBlogHub.API.Models.Domain
{
	public class Category
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool UrlHandle { get; set; }
    }
}