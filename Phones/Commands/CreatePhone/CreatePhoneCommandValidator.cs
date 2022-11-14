using FluentValidation;
using System;

namespace MobileStore.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Company).NotEmpty().MaximumLength(250);
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            RuleFor(createPhoneCommand => createPhoneCommand.Price).NotEmpty();
        }
    }
}
