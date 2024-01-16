﻿
using Microsoft.EntityFrameworkCore;
using SocialApp.Server.Data;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly DataContext _context;

        public CategoryService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            category.Editing = category.IsNew = false;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategories(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null) {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }
 
            category.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();  
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            var response = new ServiceResponse<List<Category>>();
            try
            {
                response.Data = await _context.Categories
                    .Where(c => !c.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var response = new ServiceResponse<List<Category>>();
            try
            {
                response.Data = await _context.Categories
                    .Where(c => !c.Deleted && c.Visible)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Category>>> UpdateCategories(Category category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }   

            dbCategory.Name = category.Name;
            dbCategory.Description = category.Description;
            dbCategory.Url = category.Url;
            dbCategory.Visible = category.Visible;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }   

    }
}
