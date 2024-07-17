using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebDbApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "A name must have a length of at least 2 characters.")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

    }
}
