using AutoMapper;
using BizLand.Business.DTOs.ProfessionDto;
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
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }
        public async Task Create(ProfessionCreateDto dto)
        {
            if (dto != null)
            {
                var profession = _mapper.Map<Profession>(dto);
                await _professionRepository.CreateAsync(profession);
                await _professionRepository.CommitAsync();
            }

        }

        public async Task Delete(int id)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (profession != null)
            {
                _professionRepository.Delete(profession);
                await _professionRepository.CommitAsync();
            }
        }

        public async Task<List<ProfessionGetDto>> GetAllAsync()
        {
            var profession = await _professionRepository.GetAllAsync();

            var profession2 = profession.Select(x => new ProfessionGetDto()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();

            return profession2;
        }

        public async Task<ProfessionGetDto> GetByIdAsync(int id)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == id);
            var prodto = _mapper.Map<ProfessionGetDto>(profession);
            return prodto;
        }

        public async Task SoftDelete(int id)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (profession != null)
            {
                profession.IsDeleted = !profession.IsDeleted;
                await _professionRepository.CommitAsync();
            }
        }

        public async Task Update(ProfessionUpdateDto dto)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (profession != null)
            {
                profession = _mapper.Map(dto, profession);
                await _professionRepository.CommitAsync();
            }
        }
    }
}