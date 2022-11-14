using MediatR;
using System;

namespace MobileStore.Phones.Queries.GetPhoneList
{
    public class GetPhoneListQuery:IRequest<PhoneListVm>
    {
        public Guid UserId { get; set; }

    }
}
