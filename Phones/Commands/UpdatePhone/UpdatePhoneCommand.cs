using MediatR;
using System;

namespace MobileStore.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommand : IRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public string Company { get; set; }
        public int Price { get; set; }

    }
}
