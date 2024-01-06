using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.DTOs.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task Create(EmployeeCreateDto dto);
        Task Update(EmployeeUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<EmployeeGetDto> GetByIdAsync(int id);
        Task<List<EmployeeGetDto>> GetAllAsync();
    }
}
