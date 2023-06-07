using AutoMapper;

namespace BackendApi.Profiles
{
    public class GridProfile: Profile
    {
        public GridProfile() 
        {
            CreateMap<Entities.Grid, Models.GridDto>();
            CreateMap<Models.GridForCreationDto, Entities.Grid>();
        }
    }
}
