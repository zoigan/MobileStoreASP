using AutoMapper;
using MobileStore.Common.Mappings;
using MobileStore.Models;

namespace MobileStore.Phones.Queries.GetPhoneDetails
{
    public class PhoneDetailsVm:IMapWith<Phone>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Phone, PhoneDetailsVm>()
                    .ForMember(phoneVm => phoneVm.Name, opt => opt.MapFrom(phone => phone.Name))
                    .ForMember(phoneVm => phoneVm.Company, opt => opt.MapFrom(phone => phone.Company))
                    .ForMember(phoneVm => phoneVm.Price, opt => opt.MapFrom(phone => phone.Price))
                    .ForMember(phoneVm => phoneVm.Id, opt => opt.MapFrom(phone => phone.Id));
                
        }
    }
}
