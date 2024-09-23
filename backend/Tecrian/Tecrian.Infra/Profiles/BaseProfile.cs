using AutoMapper;
using Tecrian.Domain.Entities;
using Tecrian.Shared.Dtos;
using Tecrian.Shared.Utils.Hash;

namespace Tecrian.Infra.Profiles;

public class TecrianMapProfile : Profile
{
    public TecrianMapProfile()
    {
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashUtils.HashPassword(src.Password ?? "")))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsEmailVerified, opt => opt.Ignore());

        CreateMap<User, UpdateUserDto>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}
