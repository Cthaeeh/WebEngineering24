using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyWebDbApp.Areas.Identity.Data;

namespace MyWebDbApp.Models
{
    public class Department
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Chief is required.")]
        public string ChiefId { get; set; }

        [ForeignKey("ChiefId")]
        public AppUser Chief { get; set; }

        public ICollection<AppUser> Employees { get; set; } = new List<AppUser>();
    }
}