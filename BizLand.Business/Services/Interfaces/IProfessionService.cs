using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.DTOs.ProfessionDto;

namespace BizLand.Business.Services.Interfaces
{
    public interface IProfessionService
    {
        Task Create(ProfessionCreateDto dto);
        Task Update(ProfessionUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<ProfessionGetDto> GetByIdAsync(int id);
        Task<List<ProfessionGetDto>> GetAllAsync();
    }
}
