using FluentValidation;
using UserSystem_xUnitTest.Api.DTOs;

namespace UserSystem_xUnitTest.Api.Validators
{
    public sealed class CreateUserDtoValidator: AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.FullName)

                .NotEmpty()
                .WithMessage("FullName can not be empty.")

                .MinimumLength(3)
                .WithMessage("FullName must be greater than 3 letters.");
        }
    }
}
