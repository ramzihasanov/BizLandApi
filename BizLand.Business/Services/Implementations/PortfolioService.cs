using AutoMapper;
using BizLand.Business.DTOs.PortfolioDto;
using BizLand.Business.Extensions;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace BizLand.Business.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper, IWebHostEnvironment webHost)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _webHost = webHost;
        }

        public async Task Create(PortfolioCreateDto dto)
        {
            var portfolio = new Portfolio();
            if (dto.FormFile.FileName != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1048576)
                {
                    throw new Exception();

                }
                portfolio = _mapper.Map<Portfolio>(dto);
                portfolio.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Portofolios", dto.FormFile);
            }

            await _portfolioRepository.CreateAsync(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == id);
            if (portfolio == null)
            {
                throw new Exception();
            }

            if (!string.IsNullOrEmpty(portfolio.ImageUrl))
            {
                if (System.IO.File.Exists(portfolio.ImageUrl))
                {
                    System.IO.File.Delete(portfolio.ImageUrl);
                }
            }

            _portfolioRepository.Delete(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public async Task<List<PortfolioGetDto>> GetAllAsync()
        {
            var portfolios = await _portfolioRepository.GetAllAsync();
            var portfoliodto = portfolios.Select(x => new PortfolioGetDto()
            {
                Title = x.Title,
                CategoryId = x.CategoryId,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return portfoliodto;
        }

        public async Task<PortfolioGetDto> GetByIdAsync(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == id);
            var portfoliodto = _mapper.Map<PortfolioGetDto>(portfolio);
            return portfoliodto;
        }

        public async Task SoftDelete(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == id);
            if (portfolio != null)
            {
                portfolio.IsDeleted = !portfolio.IsDeleted;
                await _portfolioRepository.CommitAsync();
            }
        }

        public async Task Update(PortfolioUpdateDto dto)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (portfolio != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1048576)
                {
                    throw new Exception();
                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Portofolios", portfolio.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                portfolio.ImageUrl = Helpers.SaveFile(_webHost.WebRootPath, "Uploads/Portofolios", dto.FormFile);
            }


            portfolio.Title = dto.Title;
            portfolio.CategoryId = dto.CategoryId;
            await _portfolioRepository.CommitAsync();
        }
    }
}