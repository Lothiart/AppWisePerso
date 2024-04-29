using Services.DTOs.CategoryDTOs;
using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class CategoryRepository(DriveWiseContext context, CategoryMapper categoryMapper, ILogger<CategoryRepository> logger) : ICategoryRepository
{
    public async Task<CategoryAddDto> AddAsync(CategoryAddDto categoryAddDto)
    {
        Category? c = await context.Categories.FirstOrDefaultAsync(c => c.Name.ToUpper() == categoryAddDto.Name.ToUpper());

        if (c is null)
        {
            Category newCategory = categoryMapper.CategoryAddDtoToCategory(categoryAddDto);
            await context.AddAsync(newCategory);

            return categoryAddDto;
        }
        else throw new Exception("Category already exists");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Category c = await context.Categories.FindAsync(id) ?? throw new Exception("Category not found");

            context.Categories.Remove(c);

            return await context.SaveChangesAsync() == 1 ? true : false;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to delete category");
            throw;
        }
    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        try
        {
            List<Category> categories = await context.Categories.ToListAsync();

            return categoryMapper.ListCategoryToListCategoryGetDto(categories);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get categories");
            throw;
        }
    }

    public async Task<CategoryGetDto> GetByIdAsync(int id)
    {
        Category c = await context.Categories.FindAsync(id) ?? throw new Exception("Category not found");

        return categoryMapper.CategoryToCategoryGetDto(c);
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto categoryDto)
    {
        Category c = await context.Categories.FindAsync(categoryDto.Id) ?? throw new Exception("Category not found");

        c.Name = categoryDto.Name;

        return await context.SaveChangesAsync() == 1 ? true : false;
    }
}
