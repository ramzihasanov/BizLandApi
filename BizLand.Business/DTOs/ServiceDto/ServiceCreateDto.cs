using FluentValidation;

namespace BizLand.Business.DTOs.ServiceDto
{
    public class ServiceCreateDto
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30);
            RuleFor(x => x.LogoUrl)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);


        }
    }
}