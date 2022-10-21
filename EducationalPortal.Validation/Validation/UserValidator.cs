using EducationalPortal.Domain.Entities;
using FluentValidation;

namespace EducationalPortal.Validation.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name can`t be empty")
                                      .MinimumLength(3).WithMessage("Minimal length of name is 3 symbols")
                                      .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
            RuleFor(user => user.FamilyName).NotEmpty().WithMessage("Familyname can`t be empty")
                                            .MinimumLength(3).WithMessage("Minimal length of familyname is 3 symbols")
                                            .MaximumLength(50).WithMessage("Miximal length of familyname is 50 symbols");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email can`t be empty")
                                       .MinimumLength(3).WithMessage("Minimal length of email is 3 symbols")
                                       .MaximumLength(50).WithMessage("Miximal length of email is 50 symbols");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Password can`t be empty")
                                       .MinimumLength(6).WithMessage("Minimal length of password is 6 symbols")
                                       .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
        }
    }
}
