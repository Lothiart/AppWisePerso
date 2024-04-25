
using Entities.Contexts;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;
using DTOs.DTOs.ModelDTOs;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ModelRepository : IModelRepository
    {
        DriveWiseContext driveWiseContext;
        ILogger<CityRepository> logger;

        public ModelRepository(DriveWiseContext driveWiseContext, ILogger<CityRepository> logger)
        {
            this.driveWiseContext = driveWiseContext;
            this.logger = logger;
        }
        public async Task AddAsync(ModelAddDto modelAddDto)
        {
            try
            {
                await driveWiseContext.AddAsync(new Model() { BrandId = modelAddDto.BrandId, ImgUrl =  modelAddDto.ImgUrl, Name = modelAddDto.Name });
                await driveWiseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }

        }

        public async Task<ModelGetDto> GetByIdAsync(int id)
        {
            try
            {
                Model model = await driveWiseContext.Models.FirstOrDefaultAsync(m => m.Id == id);
                return new ModelGetDto() { Id = model.Id, Name = model.Name, BrandId = model.BrandId, ImgUrl = model.ImgUrl };
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }

        }

        public async Task<List<ModelGetDto>> GetAllAsync()
            {
            try
            {
                List<Model> models = await driveWiseContext.Models.ToListAsync();
                List<ModelGetDto> modelsDto = new List<ModelGetDto>();
                foreach (Model model in models)
                {
                    modelsDto.Add(new ModelGetDto() { Id = model.Id, Name = model.Name, BrandId = model.BrandId, ImgUrl = model.ImgUrl });
                }
                return modelsDto;
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task UpdateAsync(ModelUpdateDto modelUpdateDto)
        {
            try
            {
                Model model = await driveWiseContext.Models.FirstOrDefaultAsync(c => c.Id == modelUpdateDto.Id);
                model.Name = modelUpdateDto.Name;
                model.BrandId = modelUpdateDto.BrandId;
                model.ImgUrl = modelUpdateDto.ImgUrl;
                driveWiseContext.Models.Update(model);
                await driveWiseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task<List<ModelGetDto>> GetByBrandAsync(Brand brand)
        {
            try
            {
                List<Model> models = await driveWiseContext.Models.Where(p => p.BrandId == brand.Id).Include(p => p.Brand).ToListAsync();
                List<ModelGetDto> modelsDto = new List<ModelGetDto>();

                foreach (Model model in models)
                {
                    modelsDto.Add(new ModelGetDto() { Id = model.Id, BrandId = model.BrandId, Name = model.Name, ImgUrl = model.ImgUrl });
                }
                return modelsDto;
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Model model = await driveWiseContext.Models.FirstOrDefaultAsync(c => c.Id == id);
                driveWiseContext.Models.Remove(model);
                await driveWiseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }
    }
}
