using EducationalPortal.Domain.Entities;
using FluentValidation;

namespace EducationalPortal.Validation.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        private string[] bookFormats = { "epub", "fb2", "txt", "mobi", "djvu", "pdf", "rtf", "lrf", "doc" };

        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().WithMessage("Name can`t be empty")
                                      .MinimumLength(3).WithMessage("Minimal length of name is 3 symbols")
                                      .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
            RuleFor(book => book.PageCount).NotNull().WithMessage("Every book has pages")
                                           .GreaterThan(10).WithMessage("quality of pages mast be more than 10");
            RuleFor(book => book.Format).NotEmpty().WithMessage("This field cant be empty")
                                        .NotNull().WithMessage("This field cant be empty")
                                        .Must(IsValidFormat).WithMessage("admissible formats: epub, fb2, txt, mobi, djvu, pdf, rtf, lrf,doc");
        }

        private bool IsValidFormat(string format)
        {
            bool result = false;
            foreach (var item in bookFormats)
            {
                if (item.Equals(format))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
