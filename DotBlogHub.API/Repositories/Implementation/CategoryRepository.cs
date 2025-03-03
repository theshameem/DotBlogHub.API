﻿using DotBlogHub.API.Data;
using DotBlogHub.API.Models.Domain;
using DotBlogHub.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotBlogHub.API.Repositories.Implementation
{
	public class CategoryRepository : ICategoryRepository
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

		public async Task<Category?> DeleteAsync(Guid id)
		{
			var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

			if(existingCategory != null)
			{
				dbContext.Remove(existingCategory);
				await dbContext.SaveChangesAsync();
				return existingCategory;
			}

			return null;
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await dbContext.Categories.ToListAsync();
		}

		public async Task<Category?> GetCategoryByIdAsync(Guid id)
		{
			return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Category?> UpdateAsync(Category category)
		{
			var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);	
			if (existingCategory != null)
			{
				dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
				await dbContext.SaveChangesAsync();
				return category;
			}

			return null;
		}
	}
}
