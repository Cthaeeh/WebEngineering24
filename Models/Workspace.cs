using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebDbApp.Models
{
    public class Workspace : IValidatableObject
    {

        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string Name { get; set; }

        public int RoomId { get; set; }

        // TODO, add Ausstattung
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}