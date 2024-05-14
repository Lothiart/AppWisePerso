using Services.DTOs.CategoryDTOs;
using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;


namespace Repositories;
public class CategoryRepository(DriveWiseContext context, CategoryMapper categoryMapper, ILogger<CategoryRepository> logger) : ICategoryRepository
{
    public async Task<CategoryAddDto> AddAsync(CategoryAddDto categoryAddDto)
    {
        Category? c = await context.Categories.FirstOrDefaultAsync(c => c.Name.ToUpper().Trim() == categoryAddDto.Name.ToUpper().Trim());

        if (c is not null) return null;

        Category newCategory = categoryMapper.CategoryAddDtoToCategory(categoryAddDto);
        await context.AddAsync(newCategory);
        await context.SaveChangesAsync();

        return categoryAddDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Category? c = await context.Categories.FindAsync(id);

            if (c is null) return false;

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
        Category? c = await context.Categories.FindAsync(id);

        if (c is null) return null;

        return categoryMapper.CategoryToCategoryGetDto(c);
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto categoryDto)
    {
        Category? c = await context.Categories.FindAsync(categoryDto.Id);

        if (c is null) return false;

        c.Name = categoryDto.Name;

        return await context.SaveChangesAsync() == 1 ? true : false;
    }
}
