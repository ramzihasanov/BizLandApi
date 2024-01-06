using AutoMapper.Execution;
using AutoMapper;
using BizLand.Business.Extensions;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLand.Core.Entities;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Repository.Interfaces;
using BizLand.Business.DTOs.EmployeeDto;

namespace BizLand.Business.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IWebHostEnvironment webHost)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task Create(EmployeeCreateDto dto)
        {
            var emp = new Employee();
            if (dto.FormFile != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1048576)
                {
                    throw new Exception();

                }
                emp = _mapper.Map<Employee>(dto);
                emp.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Employees", dto.FormFile);
            }

            await _employeeRepository.CreateAsync(emp);
            await _employeeRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var emp = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            if (emp == null)
            {
                throw new Exception();
            }

            if (!string.IsNullOrEmpty(emp.ImageUrl))
            {
                if (System.IO.File.Exists(emp.ImageUrl))
                {
                    System.IO.File.Delete(emp.ImageUrl);
                }
            }

            _employeeRepository.Delete(emp);
            await _employeeRepository.CommitAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var emp = await _employeeRepository.GetAllAsync();
            var employedto = emp.Select(x => new EmployeeGetDto()
            {
                FaceUrl = x.FaceUrl,
                InstaUrl = x.InstaUrl,
                TwitUrl = x.TwitUrl,
                LinkedinUrl=x.LnedinUrl,
                FullName = x.FullName,
                ProfessionId = x.ProfessionId,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return employedto;
        }

        public async Task<EmployeeGetDto> GetByIdAsync(int id)
        {
            var employe = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            var employeedto = _mapper.Map<EmployeeGetDto>(employe);
            return employeedto;
        }

        public async Task SoftDelete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            if (employee != null)
            {
                employee.IsDeleted = !employee.IsDeleted;
                await _employeeRepository.CommitAsync();
            }
        }

        public async Task Update(EmployeeUpdateDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (employee != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1048576)
                {
                    throw new Exception();

                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Employees", employee.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                employee.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Employees", dto.FormFile);
            }

            employee.FullName = dto.FullName;
            employee.InstaUrl = dto.InstaUrl;
            employee.TwitUrl = dto.TwitUrl;
            employee.LnedinUrl = dto.LinkedinUrl;
            employee.FaceUrl = dto.FaceUrl;
            employee.ProfessionId = dto.ProfessionId;
            await _employeeRepository.CommitAsync();
        }
    }
}