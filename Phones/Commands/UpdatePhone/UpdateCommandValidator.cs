using FluentValidation;
using MobileStore.Phones.Commands.CreatePhone;
using System;

namespace MobileStore.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandValidator : AbstractValidator<UpdatePhoneCommand>
    {
        public UpdatePhoneCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Company).NotEmpty().MaximumLength(250);
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            RuleFor(createPhoneCommand => createPhoneCommand.Price).NotEmpty();
        }
    }
}
