using EducationalPortal.Domain.Entities;
using FluentValidation;

namespace EducationalPortal.Validation.Validation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(course => course.Name).NotEmpty().WithMessage("Name can`t be empty")
                                          .MinimumLength(3).WithMessage("Minimal length of name is 3 symbols")
                                          .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
            RuleFor(course => course.Description).NotEmpty().WithMessage("Name can`t be empty")
                                                 .MinimumLength(50).WithMessage("Minimal length of name is 50 symbols")
                                                 .MaximumLength(200).WithMessage("Miximal length of name is 200 symbols");
        }
    }
}
