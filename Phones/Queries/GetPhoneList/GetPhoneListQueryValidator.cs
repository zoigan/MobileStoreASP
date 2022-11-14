using FluentValidation;
using MobileStore.Phones.Queries.GetPhoneDetails;
using System;

namespace MobileStore.Phones.Queries.GetPhoneList
{
    public class GetPhoneListQueryValidator : AbstractValidator<GetPhoneListQuery>
    {
        public GetPhoneListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
