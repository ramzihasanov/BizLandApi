using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.DTOs.SliderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface ISliderService
    {
        Task Create(SliderCreateDto dto);
        Task Update(SliderUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<SliderGetDto> GetByIdAsync(int id);
        Task<List<SliderGetDto>> GetAllAsync();
    }
}
