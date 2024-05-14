using Services.DTOs.CategoryDTOs;
using Entities;


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

        foreach (var category in categories)
        {
            categoryDtos.Add(CategoryToCategoryGetDto(category));
        }

        return categoryDtos;
    }
    #endregion
}