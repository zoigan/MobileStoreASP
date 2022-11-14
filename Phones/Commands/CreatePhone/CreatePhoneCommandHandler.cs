using MediatR;
using MobileStore.Interfaces;
using MobileStore.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandHandler
        : IRequestHandler<CreatePhoneCommand, int>
    {
        private readonly IMobilDbContext _mobilDbContext;

        public CreatePhoneCommandHandler(IMobilDbContext mobilDbContext) =>
            _mobilDbContext = mobilDbContext;
        public async Task<int> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = new Phone
            {
                Id = request.Id,
                Name = request.Name,
                Company = request.Company,
                Price = request.Price
            };

            await _mobilDbContext.Phones.AddAsync(phone, cancellationToken);
            await _mobilDbContext.SaveChangesAsync(cancellationToken);
            return phone.Id;

        }
    }
}
