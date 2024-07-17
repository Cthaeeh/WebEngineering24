namespace MyWebDbApp.Models
{
    public class RoomUtilizationViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OnSiteCount { get; set; }
        public int HomeOfficeCount { get; set; }
        public int RoomId { get; set; }
        public int EmployeeCount { get; set; }
    }
}
