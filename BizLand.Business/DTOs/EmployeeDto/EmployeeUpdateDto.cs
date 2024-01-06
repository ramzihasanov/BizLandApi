using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BizLand.Business.DTOs.EmployeeDto
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public IFormFile FormFile { get; set; }
    }

    public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.LinkedinUrl)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.InstaUrl)
               .NotEmpty()
               .MaximumLength(30);
            RuleFor(x => x.TwitUrl)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.FaceUrl)
                .NotEmpty()
                .MaximumLength(30);


        }
    }
}