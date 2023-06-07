using BackendApi.Helpers;

namespace BackendApi.Models
{
    public class CordinatesDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
