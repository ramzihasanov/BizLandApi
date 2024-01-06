using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
namespace BizLand.Business.DTOs.EmployeeDto
{
    public class EmployeeCreateDto
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitUrl { get; set; }
        public IFormFile FormFile { get; set; }
    }

    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.InstaUrl)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.TwitUrl)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.LinkedinUrl)
              .NotEmpty()
              .MaximumLength(30);
            RuleFor(x => x.FaceUrl)
                .NotEmpty()
                .MaximumLength(30);


        }
    }

}