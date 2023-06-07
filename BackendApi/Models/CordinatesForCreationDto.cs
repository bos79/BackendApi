using System.ComponentModel.DataAnnotations;

namespace BackendApi.Models
{
    public class CordinatesForCreationDto
    {
        [Required(ErrorMessage = "You should provide valid Status value.")]
        [MaxLength(50)]
        public string Status { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
