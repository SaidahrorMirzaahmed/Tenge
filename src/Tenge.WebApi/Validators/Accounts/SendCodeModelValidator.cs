using FluentValidation;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Accounts;

namespace Tenge.WebApi.Validators.Accounts;

public class SendCodeModelValidator : AbstractValidator<SendCodeModel>
{
    public SendCodeModelValidator()
    {

        RuleFor(sc => sc.Email)
            .NotNull()
            .WithMessage(sc => $"{nameof(sc.Email)} is not specified");

        RuleFor(sc => sc.Email)
            .Must(ValidationHelper.IsEmailValid);
    }
}