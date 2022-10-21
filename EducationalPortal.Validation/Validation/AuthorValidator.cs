using EducationalPortal.Domain.Entities;
using FluentValidation;

namespace EducationalPortal.Validation.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.Name).NotEmpty().WithMessage("Name can`t be empty")
                                          .MinimumLength(3).WithMessage("Minimal length of name is 3 symbols")
                                          .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
        }
    }
}
