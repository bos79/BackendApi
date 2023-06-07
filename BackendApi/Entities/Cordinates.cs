using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendApi.Entities
{
    public class Cordinates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Col { get; set; }

        [ForeignKey("GridId")]
        public Grid? Grid { get; set; }

        public int GridId { get; set; }

        public Cordinates(string status) 
        {
            Status = status;
           
        }
    }
}
