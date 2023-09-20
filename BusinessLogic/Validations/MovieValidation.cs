using Core.DTOs;
using FluentValidation;

namespace Core.Validations
{
    public class MovieValidation : AbstractValidator<MovieDTO>
    {
        public MovieValidation()
        {
            RuleFor(movie => movie.Title)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(200)
               .WithMessage("Value {PropertyValue} is incorrect. {PropertyName} is required and must be len greater 2... ");

            RuleFor(movie => movie.Year)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Value {PropertyValue} of property {PropertyName} is incorrect.");

            RuleFor(product => product.Duration)
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(product => product.Description)
                .NotNull()
                .WithMessage("{PropertyName} is required");

        }
    }
}
