using System.ComponentModel.DataAnnotations;

namespace MyWebDbApp.Models
{
    public class Workspace : IValidatableObject
    {

        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string Name { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }  // Add this navigation property

        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
        
        public ICollection<Occupancy> Occupancies { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}