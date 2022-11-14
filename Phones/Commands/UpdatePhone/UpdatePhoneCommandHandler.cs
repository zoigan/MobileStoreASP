using MediatR;
using MobileStore.Interfaces;
using MobileStore.Models;
using MobileStore.Phones.Commands.CreatePhone;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MobileStore.Phones.Commands.Exceptions;

namespace MobileStore.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandHandler 
        : IRequestHandler<UpdatePhoneCommand>
    {
        private readonly IMobilDbContext _mobilDbContext;

        public UpdatePhoneCommandHandler(IMobilDbContext mobilDbContext) =>
            _mobilDbContext = mobilDbContext;
        public async Task<Unit> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = await _mobilDbContext.Phones.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new PhoneFoundException(nameof(Phone), request.Id);
            }
            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.Company = request.Company;

            await _mobilDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
