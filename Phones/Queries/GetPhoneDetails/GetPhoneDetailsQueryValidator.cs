using FluentValidation;
using MobileStore.Phones.Commands.DeletePhone;
using System;

namespace MobileStore.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQueryValidator : AbstractValidator<GetPhoneDetailsQuery>
    {
        public GetPhoneDetailsQueryValidator()
        {

            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
