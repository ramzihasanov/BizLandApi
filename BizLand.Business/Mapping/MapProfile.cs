using AutoMapper;
using BizLand.Business.DTOs.AccountDto;
using BizLand.Business.DTOs.CategoryDto;
using BizLand.Business.DTOs.EmployeeDto;
using BizLand.Business.DTOs.PortfolioDto;
using BizLand.Business.DTOs.ProfessionDto;
using BizLand.Business.DTOs.ServiceDto;
using BizLand.Business.DTOs.SliderDto;
using BizLand.Core.Entities;

namespace BizLand.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Slider, SliderGetDto>().ReverseMap();
            CreateMap<Slider, SliderCreateDto>().ReverseMap();
            CreateMap<Slider, SliderUpdateDto>().ReverseMap();

            CreateMap<Service, ServiceGetDto>().ReverseMap();
            CreateMap<Service, ServiceCreateDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<Profession, ProfessionCreateDto>().ReverseMap();
            CreateMap<Profession, ProfessionGetDto>().ReverseMap();
            CreateMap<Profession, ProfessionUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<Portfolio, PortfolioGetDto>().ReverseMap();
            CreateMap<Portfolio, PortfolioCreateDto>().ReverseMap();
            CreateMap<Portfolio, PortfolioUpdateDto>().ReverseMap();

            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();

        }

    }
}