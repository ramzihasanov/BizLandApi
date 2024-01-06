using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.PortfolioDto
{
    public class PortfolioCreateDto
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class PortfolioCreateValidator : AbstractValidator<PortfolioCreateDto>
    {
        public PortfolioCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}