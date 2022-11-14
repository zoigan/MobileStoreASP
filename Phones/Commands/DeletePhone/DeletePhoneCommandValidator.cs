using FluentValidation;
using MobileStore.Phones.Commands.UpdatePhone;
using System;

namespace MobileStore.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommandValidator : AbstractValidator<DeletePhoneCommand>
    {
        public DeletePhoneCommandValidator()
        {
            RuleFor(d => d.Id).NotNull();
            RuleFor(d => d.UserId).NotEqual(Guid.Empty);
        }
    }
}
