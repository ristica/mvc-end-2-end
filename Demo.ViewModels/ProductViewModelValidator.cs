using FluentValidation;

namespace Demo.ViewModels
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(x => x.ProductPrice)
                .NotNull().WithMessage("Required");

            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Required")
                .Length(2, 20).WithMessage("Product name musst be between 2 and 20 characters.");

            RuleFor(x => x.ProductPrice)
                .GreaterThan(0).WithMessage("Product price musst be in positive range.");
        }
    }
}
