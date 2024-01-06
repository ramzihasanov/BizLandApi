using AutoMapper;
using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;

namespace BizLand.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Create(CategoryCreateDto dto)
        {
            if (dto != null)
            {
                var category = _mapper.Map<Category>(dto);
                await _categoryRepository.CreateAsync(category);
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();

            var categoryGetDtos = category.Select(x => new CategoryGetDto()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
            return categoryGetDtos;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            var categoryGetdto = _mapper.Map<CategoryGetDto>(category);
            return categoryGetdto;
        }

        public async Task SoftDelete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category != null)
            {
                category.IsDeleted = !category.IsDeleted;
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task Update(CategoryUpdateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (category != null)
            {
                category = _mapper.Map(dto, category);
                await _categoryRepository.CommitAsync();
            }
        }
    }
}