using BackendApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApi.Entities
{
    public class Grid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public ICollection<Cordinates> Cordinates { get; set; }
               = new List<Cordinates>();

        public Grid(string name) 
        {
            Name = name;
        }
    }
}
