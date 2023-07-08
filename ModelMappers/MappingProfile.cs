using AutoMapper;
using BusinessEntityModels;
using DataEntityModels;

namespace ModelMappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BusinessEntityBase, DataEntityBase>()
            .ForMember(dest => dest.ActionType, opt => opt.MapFrom(src => src.OpertionType))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.DateUpdated))
            .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.ModifiedBy));
        CreateMap<DataEntityBase, BusinessEntityBase>()
            .ForMember(dest => dest.OpertionType, opt => opt.MapFrom(src => src.ActionType))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.DateUpdated, opt => opt.MapFrom(src => src.UpdatedOn))
            .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.UpdatedBy));
    }
}
