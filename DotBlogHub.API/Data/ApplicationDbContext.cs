﻿using DotBlogHub.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotBlogHub.API.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
