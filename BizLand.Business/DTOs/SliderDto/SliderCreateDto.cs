using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.SliderDto
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ButtonText { get; set; }
        public string VideoUrl { get; set; }
        public string ButtonUrl { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Desc)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.ButtonText)
                .NotEmpty().
                MaximumLength(100);
            RuleFor(x => x.VideoUrl)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}