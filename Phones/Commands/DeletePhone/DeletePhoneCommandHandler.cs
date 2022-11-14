using MediatR;
using MobileStore.Interfaces;
using MobileStore.Models;
using MobileStore.Phones.Commands.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommandHandler
        : IRequestHandler<DeletePhoneCommand>
    {
        private readonly IMobilDbContext _mobilDbContext;

        public DeletePhoneCommandHandler(IMobilDbContext mobilDbContext) =>
            _mobilDbContext = mobilDbContext;

        public async Task<Unit> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = await _mobilDbContext.Phones.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new PhoneFoundException(nameof(Phone), request.Id);
            }
            _mobilDbContext.Phones.Remove(entity);
            await _mobilDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
