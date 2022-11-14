using AutoMapper;
using MobileStore.Common.Mappings;
using MobileStore.Phones.Commands.CreatePhone;
using MobileStore.Phones.Commands.UpdatePhone;

namespace MobileStore.Models.DTO
{
    public class UpdatePhoneDto : IMapWith<UpdatePhoneCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePhoneDto, UpdatePhoneCommand>()
                .ForMember(phoneCommand => phoneCommand.Id, opt => opt.MapFrom(phoneDto => phoneDto.Id))
                .ForMember(phoneCommand => phoneCommand.Name, opt => opt.MapFrom(phoneDto => phoneDto.Name))
                .ForMember(phoneCommand => phoneCommand.Company, opt => opt.MapFrom(phoneDto => phoneDto.Company))
                .ForMember(phoneCommand => phoneCommand.Price, opt => opt.MapFrom(phoneDto => phoneDto.Price));

        }
    }
}
