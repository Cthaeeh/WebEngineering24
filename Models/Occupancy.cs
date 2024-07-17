using System.ComponentModel.DataAnnotations;
using MyWebDbApp.Areas.Identity.Data;
using MyWebDbApp.Models;

namespace MyWebDbApp.Models
{
    public class Occupancy
    {
        public int Id { get; set; }
        public int RoomId { get; set; }  
        public int? EmployeeId { get; set; }
        public string? UserId { get; set; }
        public enum FeaturesType
        {
            None,
            Ruheraum,
            Partyraum,
            Schlafraum,
        }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // Navigation properties
        public Room? Room { get; set; }

        public FeaturesType Features { get; set; }
        public Employee? Employee { get; set; }
        public AppUser? User { get; set; }   
    }

}
