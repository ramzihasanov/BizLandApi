using AutoMapper;
using BizLand.Business.DTOs.SliderDto;
using BizLand.Business.Extensions;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using BizLand.Data.DAL;
using Microsoft.AspNetCore.Hosting;

namespace BizLand.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _appDb;
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _webHost;
        private readonly IMapper _mapper;

        public SliderService(AppDbContext appDb, ISliderRepository sliderRepository, IWebHostEnvironment webHost, IMapper mapper)
        {
            _appDb = appDb;
            _sliderRepository = sliderRepository;
            _webHost = webHost;
            _mapper = mapper;
        }
        public async Task Create(SliderCreateDto slider)
        {
            var newSlider = new Slider();
            if (slider.FormFile.FileName != null)
            {

                if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (slider.FormFile.Length > 1048576)
                {
                    throw new Exception();

                }
                newSlider = _mapper.Map<Slider>(slider);
                newSlider.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Sliders", slider.FormFile);
            }

            await _sliderRepository.CreateAsync(newSlider);
            await _sliderRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            Slider slider = await _sliderRepository.GetByIdAsync(x => x.Id == id);
            if (slider == null) throw new Exception();
           else
            {

                if (!string.IsNullOrEmpty(slider.ImageUrl))
                {
                    if (System.IO.File.Exists(slider.ImageUrl))
                    {
                        System.IO.File.Delete(slider.ImageUrl);
                    }
                }
                _sliderRepository.Delete(slider);
                await _sliderRepository.CommitAsync();
            }

        }

        public async Task<List<SliderGetDto>> GetAllAsync()
        {
            var sliders = await _sliderRepository.GetAllAsync();
            var slid = sliders.Select(x => new SliderGetDto()
            {
                Title = x.Title,
                Desc = x.Desc,
                ButtonText = x.ButtonText,
                VideoUrl = x.VideoUrl,
                ButtonUrl=x.ButtonUrl,
                ImageUrl = x.ImageUrl,
            }).ToList();
            return slid;
        }

        public async Task<SliderGetDto> GetByIdAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(x => x.Id == id);
            if(slider == null) throw new Exception();
            var sld = _mapper.Map<SliderGetDto>(slider);
            return sld;
        }

        public async Task SoftDelete(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(x => x.Id == id);
            if( slider == null) throw new Exception();
            else
            {
                slider.IsDeleted = !slider.IsDeleted;
                await _sliderRepository.CommitAsync();
            }
        }

        public async Task Update(SliderUpdateDto slider)
        {
            var sld = await _sliderRepository.GetByIdAsync(x => x.Id == slider.Id);
            if(sld == null) throw new Exception();

           else
            {

                if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (slider.FormFile.Length > 1048576)
                {
                    throw new Exception();
                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Sliders", sld.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                sld.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Sliders", slider.FormFile);
            }

            sld.Title = slider.Title;
            sld.Desc = slider.Desc;
            sld.ButtonUrl = slider.ButtonUrl;
            sld.ButtonText = slider.ButtonText;
            await _sliderRepository.CommitAsync();
        }
    }
}