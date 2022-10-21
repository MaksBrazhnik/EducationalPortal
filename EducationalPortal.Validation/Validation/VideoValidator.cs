using EducationalPortal.Domain.Entities;
using FluentValidation;

namespace EducationalPortal.Validation.Validation
{
    public class VideoValidator : AbstractValidator<Video>
    {
        private string[] videoQualties = { "120p", "240p", "360p", "480p", "720p", "1080p"};

        public VideoValidator()
        {
            RuleFor(video => video.Name).NotEmpty().WithMessage("Name can`t be empty")
                                        .MinimumLength(3).WithMessage("Minimal length of name is 3 symbols")
                                        .MaximumLength(50).WithMessage("Miximal length of name is 50 symbols");
            RuleFor(video => video.Length).NotEmpty().WithMessage("Field can`t be empty")
                                          .Must(IsValidLength).WithMessage("Video length must be more then 0");
            RuleFor(video => video.Quality).NotEmpty().WithMessage("Field can`t be empty")
                                           .Must(IsValidQuality).WithMessage("admissible qualities: 120p, 240p, 360p, 480p, 720p, 1080p");
        }

        private bool IsValidLength(double length)
        {
           return (length > 0.0) ? true : false;
        }

        private bool IsValidQuality(string quality)
        {
            bool result = false;
            foreach (var item in videoQualties)
            {
                if (item.Equals(quality))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
