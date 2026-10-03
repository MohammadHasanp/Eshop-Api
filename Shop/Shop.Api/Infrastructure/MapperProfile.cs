using AutoMapper;
using Common.Domain.ValueObjects;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.EditAddress;

namespace Shop.Api.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddUserAddressViewModel, AddUserAddressCommand>().ForMember(dest => dest.Phone,
              opt => opt.MapFrom(src => new PhoneNumber(src.Phone))); 

            CreateMap<AddUserAddressCommand, AddUserAddressViewModel>()
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(src => src.Phone.Value));


            CreateMap<EditUserAddressViewModel, EditUserAddressCommand>().ForMember(dest => dest.PhoneNumber,
               opt => opt.MapFrom(src => new PhoneNumber(src.PhoneNumber)));

            CreateMap<EditUserAddressCommand, EditUserAddressViewModel>()
                .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.PhoneNumber.Value));

            CreateMap<ChangePasswordViewModel, ChangeUserPasswordCommand>().ReverseMap();
        }
    }
}
