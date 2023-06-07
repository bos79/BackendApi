using System.ComponentModel.DataAnnotations;

namespace BackendApi.Models
{
    public class CordinatesForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a Status value.")]
        [MaxLength(50)]
        public string Status { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int GridId { get; set; }
    }
}
