using FluentValidation;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.Validators.Users;

public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(user => user.FirstName)
            .NotNull()
            .WithMessage(user => $"{nameof(user.FirstName)} is not specified");

        RuleFor(user => user.Email)
            .NotNull()
            .WithMessage(user => $"{nameof(user.Email)} is not specified");

        RuleFor(user => user.Email)
            .Must(ValidationHelper.IsEmailValid);

        RuleFor(user => user.Password)
            .Must(ValidationHelper.IsPasswordHard);
    }
}