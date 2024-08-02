using AutoMapper;

namespace RealEstate.Shared.Profiles;

public class BaseProfile<TEntity, TDto> : Profile
{
    public BaseProfile()
    {
        CreateMap<TEntity, TDto>();
        CreateMap<TDto, TEntity>();
    }
}
