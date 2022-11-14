using AutoMapper;
using MobileStore.Common.Mappings;
using MobileStore.Phones.Commands.CreatePhone;
using MobileStore.Phones.Queries.GetPhoneDetails;

namespace MobileStore.Models.DTO
{
    public class CreatePhoneDto:IMapWith<CreatePhoneCommand>
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhoneDto, CreatePhoneCommand>()
                    .ForMember(phoneVm => phoneVm.Name, opt => opt.MapFrom(phone => phone.Name))
                    .ForMember(phoneVm => phoneVm.Company, opt => opt.MapFrom(phone => phone.Company))
                    .ForMember(phoneVm => phoneVm.Price, opt => opt.MapFrom(phone => phone.Price));

        }
    }
}
