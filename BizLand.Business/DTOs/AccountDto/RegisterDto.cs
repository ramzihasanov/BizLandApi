using FluentValidation;
namespace BizLand.Business.DTOs.AccountDto
{
    public class RegisterDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.Fullname).NotEmpty().NotNull();
            RuleFor(x => x.Username).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }

    }
}