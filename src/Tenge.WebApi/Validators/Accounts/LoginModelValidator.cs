using FluentValidation;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Accounts;

namespace Tenge.WebApi.Validators.Accounts;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(loginModel => loginModel.Password)
            .NotNull()
            .WithMessage(loginModel => $"{nameof(loginModel.Password)} is not specified");

        RuleFor(loginModel => loginModel.Email)
            .NotNull()
            .WithMessage(loginModel => $"{nameof(loginModel.Email)} is not specified");

        RuleFor(loginModel => loginModel.Email)
            .Must(ValidationHelper.IsEmailValid);

        RuleFor(loginModel => loginModel.Password)
            .Must(ValidationHelper.IsPasswordHard);
    }
}
