using DTOs.DTOs.CategoryDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers;
public class CategoryMapper
{
    #region DtoToEntity
    public Category CategoryAddDtoToCategory(CategoryAddDto categoryDto)
    {
        Category c = new Category() { Name = categoryDto.Name };

        return c;
    }
    #endregion

    #region EntityToDto
    public CategoryGetDto CategoryToCategoryGetDto(Category category)
    {
        return new CategoryGetDto() { Id = category.Id, Name = category.Name };
    }

    public List<CategoryGetDto> ListCategoryToListCategoryGetDto(List<Category> categories)
    {
        List<CategoryGetDto> categoryDtos = new List<CategoryGetDto>();

        foreach(var category in categories)
        {
            categoryDtos.Add(CategoryToCategoryGetDto(category));
        }

        return categoryDtos;
    }
    #endregion
}
