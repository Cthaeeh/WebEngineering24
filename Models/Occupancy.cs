using MyWebDbApp.Areas.Identity.Data;

namespace MyWebDbApp.Models
{
    public class Occupancy
    {
        public int Id { get; set; }
        public int WorkspaceId { get; set; }
        public string EmployeeId { get; set; }

        public DateTime Date { get; set; }
        // Navigation properties
        public Workspace Workspace { get; set; }
        public AppUser Employee { get; set; }
    }

}