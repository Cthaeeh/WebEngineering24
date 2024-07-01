using System.ComponentModel.DataAnnotations;

namespace MyWebDbApp.Models
{
    public class Department : IValidatableObject
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string Name { get; set; }
        
        // TODO, needs additional field Chief.

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}