using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using MyWebDbApp.Models;

namespace MyWebDbApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
        public int? DepartmentId { get; set; } = null;

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
}

