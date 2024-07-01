using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebDbApp.Models
{
    public class Customer : IValidatableObject
    {
        public enum GenderType
        {
            Male,
            Female,
            Diverse
        }

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="E-Mail Address", Prompt = "name@company.com")]
        public string EMail { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public GenderType Gender { get; set; }
        [Display(Name="Share Stocks [%]")]
        [Range(0, 100)]
        public int ShareStocks { get; set; }
        [Display(Name = "Share Bonds [%]")]
        [Range(0, 100)]
        public int ShareBonds { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (ShareStocks + ShareBonds != 100)
                results.Add(new ValidationResult("The sum of shares must equal 100%."));
            
            return results;
        }
    }
}
