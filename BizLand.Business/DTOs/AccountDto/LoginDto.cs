using FluentValidation;
namespace BizLand.Business.DTOs.AccountDto
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }

    }
}