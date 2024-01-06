using BizLand.Business.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDto dto);
        Task Update(CategoryUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<List<CategoryGetDto>> GetAllAsync();
    }
}
