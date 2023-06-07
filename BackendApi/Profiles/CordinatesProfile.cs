using AutoMapper;

namespace BackendApi.Profiles
{
    public class CordinatesProfile : Profile
    {
        public CordinatesProfile() 
        { 
            CreateMap<Entities.Cordinates, Models.CordinatesDto>();
            CreateMap< Models.CordinatesForCreationDto ,Entities.Cordinates>();
            CreateMap< Models.CordinatesForUpdateDto ,Entities.Cordinates>();
            CreateMap<Entities.Cordinates, Models.CordinatesForUpdateDto>();
        }
    }
}
