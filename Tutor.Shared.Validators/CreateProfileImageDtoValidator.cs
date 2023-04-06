using FluentValidation;
using Tutor.Shared.Dtos;

namespace Tutor.Shared.Validators;

internal class CreateProfileImageDtoValidator : AbstractValidator<CreateProfileImageDto>
{
    public CreateProfileImageDtoValidator()
    {
        RuleFor(c => c.Bytes)
            .NotNull()
            .WithMessage("Profile image must not be null");
    }
}
