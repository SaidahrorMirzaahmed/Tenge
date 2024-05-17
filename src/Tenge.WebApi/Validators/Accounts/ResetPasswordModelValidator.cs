using FluentValidation;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Accounts;

namespace Tenge.WebApi.Validators.Accounts;

public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
{
    public ResetPasswordModelValidator()
    {
        RuleFor(rp => rp.NewPassword)
            .NotNull()
            .WithMessage(rp => $"{nameof(rp.NewPassword)} is not specified");

        RuleFor(rp => rp.Email)
            .NotNull()
            .WithMessage(rp => $"{nameof(rp.Email)} is not specified");

        RuleFor(rp => rp.Email)
            .Must(ValidationHelper.IsEmailValid);

        RuleFor(rp => rp.NewPassword)
            .Must(ValidationHelper.IsPasswordHard);
    }
}