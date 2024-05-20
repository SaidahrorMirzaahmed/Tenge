using FluentValidation;
using Tenge.WebApi.Models.Collections;

namespace Tenge.WebApi.Validators.Collections;

public class CollectionCreateModelValidator : AbstractValidator<CollectionCreateModel>
{
    public CollectionCreateModelValidator()
    {
        RuleFor(c=> c.Name).NotNull().NotEmpty();
        RuleFor(c=> c.Description).NotEmpty();
        RuleFor(c => c.CategoryId).NotNull().NotEqual(0);
    }  
}
