using FluentValidation;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Accounts;

namespace Tenge.WebApi.Validators.Accounts;

public class ConfirmCodeModelValidator : AbstractValidator<ConfirmCodeModel>
{
    public ConfirmCodeModelValidator()
    {
        RuleFor(cc => cc.Code)
            .NotNull()
            .WithMessage(cc => $"{nameof(cc.Code)} is not specified");

        RuleFor(cc => cc.Email)
            .Must(ValidationHelper.IsEmailValid);
    }
}
