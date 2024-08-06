using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Shared.Dtos;

namespace RealEstate.Infra.Profiles;

public class RealEstateMapProfile : Profile
{
    public RealEstateMapProfile()
    { // Map CreatePersonDto to Person
        CreateMap<CreatePersonDto, Person>().ForMember(dest => dest.Address, opt => opt.Ignore());

        // Map CreateCompanyDto to Company
        CreateMap<CreateCompanyDto, Company>()
            .ForMember(dest => dest.Address, opt => opt.Ignore())
            .ForMember(dest => dest.Representant, opt => opt.Ignore());

        // Map CreateLegalTenantDto to LegalTenant
        CreateMap<CreateLegalTenantDto, LegalTenant>()
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.StartDate, opt => opt.Ignore())
            .ForMember(dest => dest.EndDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ForMember(dest => dest.Notes, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentIds, opt => opt.Ignore());

        // Map CreateNaturalTenantDto to NaturalTenant
        CreateMap<CreateNaturalTenantDto, NaturalTenant>()
            .ForMember(dest => dest.Person, opt => opt.Ignore())
            .ForMember(dest => dest.StartDate, opt => opt.Ignore())
            .ForMember(dest => dest.EndDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ForMember(dest => dest.Notes, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentIds, opt => opt.Ignore());

        CreateMap<CreateAddressDto, Address>();
    }
}
