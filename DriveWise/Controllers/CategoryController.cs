﻿using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.DTOs.CategoryDTOs;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]

[ApiController]

public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    /// <summary>
    /// Add new category
    /// </summary>
    /// <param name="categoryAddDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<ActionResult<CategoryAddDto>> Add(CategoryAddDto categoryAddDto)
    {
        try
        {
            CategoryAddDto categoryDto = await categoryRepository.AddAsync(categoryAddDto);
            return categoryDto != null ? Ok(categoryAddDto) : NotFound("Category already exists");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Delete existing category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            bool isDeleted = await categoryRepository.DeleteAsync(id);

            return isDeleted ? Ok("Category successfully deleted") : NotFound("Category not found");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get all existing categories
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<CategoryGetDto>>> GetAll()
    {
        try
        {
            List<CategoryGetDto> categoryDto = await categoryRepository.GetAllAsync();
            return Ok(categoryDto);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get catgory by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<CategoryGetDto>> GetById(int id)
    {
        try
        {
            CategoryGetDto categoryDto = await categoryRepository.GetByIdAsync(id);
            return categoryDto != null ? Ok(categoryDto) : NotFound("Category not found");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Update existing category
    /// </summary>
    /// <param name="categoryDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateDto categoryDto)
    {
        try
        {
            bool isUpdated = await categoryRepository.UpdateAsync(categoryDto);
            return isUpdated ? Ok($"Category successfully updated to {categoryDto.Name}") : NotFound("Category not found");
        }
        catch (Exception)
        {
            throw;
        }
    }
}