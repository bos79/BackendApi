using BackendApi.Entities;

namespace BackendApi.Models
{
    public class GridDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CordinatesDto> CordinatesDto { get; set; }
               = new List<CordinatesDto>();
       
        //public CordinatesDto[][] CordinatesDto { get; set; } = new CordinatesDto[6][] ;
    }
}
