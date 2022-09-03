using FluentValidation;
using ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage;

namespace ProgramingLanguage.Application.Validators.Languages
{
    public class AddLanguageValidator : AbstractValidator<AddLanguageCommand>
    {
        public AddLanguageValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name can not be empty!");
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Name length must be greater then 2 character");
        }
    }
}
