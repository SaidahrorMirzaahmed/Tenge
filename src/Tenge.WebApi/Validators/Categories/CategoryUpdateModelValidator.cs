using FluentValidation;
using Tenge.WebApi.Models.Category;

namespace Tenge.WebApi.Validators.Categories;

public class CategoryUpdateModelValidator : AbstractValidator<CategoryUpdateModel>
{
    public CategoryUpdateModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}
