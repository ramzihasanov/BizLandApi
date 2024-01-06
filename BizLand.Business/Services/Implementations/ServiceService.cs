using AutoMapper;
using BizLand.Business.DTOs.ServiceDto;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }


        public async Task Create(ServiceCreateDto dto)
        {
            if (dto != null)
            {
                var service = _mapper.Map<Service>(dto);
                await _serviceRepository.CreateAsync(service);
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (service == null) throw new Exception();
            else
            {
                _serviceRepository.Delete(service);
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task SoftDelete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (service == null) throw new Exception();
            else
            {
                service.IsDeleted = !service.IsDeleted;
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task<List<ServiceGetDto>> GetAllAsync()
        {
            var service = await _serviceRepository.GetAllAsync();

            var service2 = service.Select(x => new ServiceGetDto()
            {
                Id = x.Id,
                LogoUrl = x.LogoUrl,
                Title = x.Title,
                Description = x.Description,

            }).ToList();

            return service2;
        }

        public async Task<ServiceGetDto> GetByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (service == null) throw new Exception();
            var service2 = _mapper.Map<ServiceGetDto>(service);
            return service2;
        }

        public async Task Update(ServiceUpdateDto dto)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (service == null) throw new Exception();
           else
            {
                service = _mapper.Map(dto, service);
                await _serviceRepository.CommitAsync();
            }
        }
    }
}