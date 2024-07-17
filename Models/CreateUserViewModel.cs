using System.ComponentModel.DataAnnotations;

namespace MyWebDbApp.Models
{

public class CreateUserViewModel
{
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    public int? DepartmentId { get; set; }
    public string RoleId { get; set; }

    public string Password { get; set; }
}

}