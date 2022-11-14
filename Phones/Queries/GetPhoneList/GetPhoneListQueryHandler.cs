using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileStore.Interfaces;
using MobileStore.Models;
using MobileStore.Phones.Commands.Exceptions;
using MobileStore.Phones.Queries.GetPhoneDetails;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace MobileStore.Phones.Queries.GetPhoneList
{
    public class GetPhoneListQueryHandler
        :IRequestHandler<GetPhoneListQuery, PhoneListVm>
    {
        private readonly IMobilDbContext _mobilDbContext;
        private readonly IMapper _mapper;

        public GetPhoneListQueryHandler(IMobilDbContext mobilDbContext, IMapper mapper)
        {
            _mobilDbContext = mobilDbContext;
            _mapper = mapper;
        }

        public async Task<PhoneListVm> Handle(GetPhoneListQuery request, CancellationToken cancellationToken)
        {
            var phonesQuery = await _mobilDbContext.Phones
                .Where(phone => phone.UserId == request.UserId)
                .ProjectTo<PhoneLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return new PhoneListVm { Phones = phonesQuery };

        }
    }
}
