using MediatR;
using System;

namespace MobileStore.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommand:IRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }


    }
}
