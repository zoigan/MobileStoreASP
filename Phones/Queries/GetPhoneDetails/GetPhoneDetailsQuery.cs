using MediatR;
using System;

namespace MobileStore.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQuery:IRequest<PhoneDetailsVm>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

    }
}
