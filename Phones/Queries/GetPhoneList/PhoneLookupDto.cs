using MobileStore.Common.Mappings;
using MobileStore.Models;
using AutoMapper;

namespace MobileStore.Phones.Queries.GetPhoneList
{
    public class PhoneLookupDto:IMapWith<Phone>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Phone, PhoneLookupDto>()
                .ForMember(phoneDto => phoneDto.Id, opt => opt.MapFrom(phone => phone.Id))
                .ForMember(phoneDto => phoneDto.Name, opt => opt.MapFrom(phone => phone.Name));
        }
    }
}
