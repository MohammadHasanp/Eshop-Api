using AutoMapper;
using Shop.Api.ViewModel.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Api.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddUserAddressViewModel, AddUserAddressCommand>().ReverseMap();
            CreateMap<EditUserAddressViewModel, EditUserAddressCommand>().ReverseMap();
        }
    }
}
