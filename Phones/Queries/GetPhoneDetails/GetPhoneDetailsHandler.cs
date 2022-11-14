using MediatR;
using MobileStore.Interfaces;
using MobileStore.Models;
using MobileStore.Phones.Commands.CreatePhone;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobileStore.Phones.Commands.Exceptions;

namespace MobileStore.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsHandler
        : IRequestHandler<GetPhoneDetailsQuery, PhoneDetailsVm>
    {
        private readonly IMobilDbContext _mobilDbContext;
        private readonly IMapper _mapper;

        public GetPhoneDetailsHandler(IMobilDbContext mobilDbContext, IMapper mapper)
        {
            _mobilDbContext = mobilDbContext;
            _mapper = mapper;
        }
            
        public async Task<PhoneDetailsVm> Handle(GetPhoneDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity  = await _mobilDbContext.Phones.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new PhoneFoundException(nameof(Phone), request.Id);
            }

            return _mapper.Map<PhoneDetailsVm>(entity);

        }
    }
}


