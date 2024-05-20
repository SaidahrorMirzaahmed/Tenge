using FluentValidation;
using Tenge.WebApi.Models.Category;

namespace Tenge.WebApi.Validators.Categories;

public class CategoryCreateModelValidator : AbstractValidator<CategoryCreateModel>
{
    public CategoryCreateModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}
