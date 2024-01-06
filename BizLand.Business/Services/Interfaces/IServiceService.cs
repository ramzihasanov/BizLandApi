using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.DTOs.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface IServiceService
    {
        Task Create(ServiceCreateDto dto);
        Task Update(ServiceUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<ServiceGetDto> GetByIdAsync(int id);
        Task<List<ServiceGetDto>> GetAllAsync();
    }
}
