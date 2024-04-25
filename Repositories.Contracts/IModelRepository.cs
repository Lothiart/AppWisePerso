using DTOs.DTOs.ModelDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IModelRepository
    {
        Task AddAsync(ModelAddDto modelAddDto);
        ModelGetDto GetByIdAsync(int id);
        List<ModelGetDto> GetAllAsync(); 
        Task UpdateAsync(ModelUpdateDto modelUpdateDto);
        Task DeleteAsync(int id);
        List<ModelGetDto> GetByBrandAsync(Brand brand);
    }
}
