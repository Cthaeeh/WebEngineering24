using Microsoft.AspNetCore.Mvc;
using MyWebDbApp.Data;
using MyWebDbApp.Models;

namespace MyWebDbApp.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly AppDbContext _context;

        public AnalysisController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var occupancyData = _context.Occupancies
                .GroupBy(o => new { o.Date, o.RoomId })  // Group Occupancies by Date and RoomId
                .Select(g => new RoomUtilizationViewModel  // Project each group into a RoomUtilizationViewModel object
                {
                    Date = g.Key.Date,                    // Set Date from the group key
                    RoomId = g.Key.RoomId,                // Set RoomId from the group key
                    EmployeeCount = g.Count(),            // Count the total number of employees in the group
                    OnSiteCount = g.Count(o => o.EmployeeId != null),    // Count employees who are on site (EmployeeId is not null)
                    HomeOfficeCount = g.Count(o => o.RoomId == 11) // Count employees working from home (EmployeeId is null)
                })
                .ToList();
            return View(occupancyData);
        }
    }
}
