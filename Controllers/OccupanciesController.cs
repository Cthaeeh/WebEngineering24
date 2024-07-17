using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Data;
using MyWebDbApp.Models;
using Microsoft.AspNetCore.Identity;
using MyWebDbApp.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace Deskbuddy.Controllers
{
    [Authorize(Roles = "Office, Chief, Worker,Administrator")]
    public class OccupanciesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OccupanciesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Occupancies
        public async Task<IActionResult> Index()
        {
            var deskbuddyContext = _context.Occupancies.Include(o => o.Employee).Include(o => o.Room).Include(o => o.Workspace);
            return View(await deskbuddyContext.ToListAsync());
        }

        // GET: Occupancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancies
                .Include(o => o.Employee)
                .Include(o => o.Room)
                .Include(o => o.Workspace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        // GET: Occupancies/Create
        [Authorize(Roles = "Office, Worker, Administrator")]
        public async Task<IActionResult> Create()
        {
            ViewData["Employees"] = await _userManager.GetUsersInRoleAsync("Worker");
            ViewData["Workspaces"] = _context.Workspaces.ToList();

            return View();
        }

        // POST: Occupancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkspaceId,EmployeeId,Date")] Occupancy occupancy)
        {
            // Find the workspace by its ID and get the associated RoomId
            var workspace = await _context.Workspaces
                                           .Include(w => w.Room)  // Include Room in the query to avoid multiple database calls
                                           .FirstOrDefaultAsync(w => w.Id == occupancy.WorkspaceId);
            if (workspace != null)
            {
                occupancy.RoomId = workspace.RoomId;
                occupancy.Room = workspace.Room;  // Assign the Room from the workspace
                occupancy.Workspace = workspace;

                // Remove the validation for these properties if they are set manually
                ModelState.Remove(nameof(occupancy.Workspace));
                ModelState.Remove(nameof(occupancy.Room));
                ModelState.Remove(nameof(occupancy.RoomId));
            }
            else
            {
                ModelState.AddModelError("WorkspaceId", "Invalid Workspace ID");
            }

            // Check if the workspace is already occupied on the specified date
            if (await IsWorkspaceOccupiedAsync(occupancy.WorkspaceId, occupancy.Date))
            {
                return CustomForbid("This workspace is already occupied on the specified date.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, log errors and return the view with errors
            Console.WriteLine("Model is not valid");
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            ViewData["Employees"] = await _userManager.GetUsersInRoleAsync("Worker");
            ViewData["Workspaces"] = _context.Workspaces.ToList();
            ViewData["Rooms"] = _context.Rooms.ToList();

            return View(occupancy);
        }
        [Authorize(Roles = "Office, Worker")]
        // GET: Occupancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancies.FindAsync(id);
            if (occupancy == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Worker"))
            {
                // Check if the current user can edit the specified occupancy
                if (occupancy.EmployeeId != currentUser.Id)
                {
                    // If the current user is not allowed to edit this occupancy, return an unauthorized view or handle accordingly
                    return Forbid();
                }
            }


            ViewData["Employees"] = await _userManager.GetUsersInRoleAsync("Worker");
            ViewData["Workspaces"] = _context.Workspaces.ToList();
            return View(occupancy);
        }

        // POST: Occupancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkspaceId,EmployeeId,Date")] Occupancy occupancy)
        {
            if (id != occupancy.Id)
            {
                return NotFound();
            }

            // Find the workspace by its ID and get the associated RoomId
            var workspace = await _context.Workspaces
                                           .Include(w => w.Room)  // Include Room in the query to avoid multiple database calls
                                           .FirstOrDefaultAsync(w => w.Id == occupancy.WorkspaceId);
            if (workspace != null)
            {
                occupancy.RoomId = workspace.RoomId;
                occupancy.Room = workspace.Room;  // Assign the Room from the workspace
                occupancy.Workspace = workspace;

                // Remove the validation for these properties if they are set manually
                ModelState.Remove(nameof(occupancy.Workspace));
                ModelState.Remove(nameof(occupancy.Room));
                ModelState.Remove(nameof(occupancy.RoomId));
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Worker") && occupancy.EmployeeId != currentUser.Id)
            {
                return Forbid();
            }

            // Check if the workspace is already occupied on the specified date
            if (await IsWorkspaceOccupiedAsync(occupancy.WorkspaceId, occupancy.Date))
            {
                return CustomForbid("This workspace is already occupied on the specified date.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occupancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccupancyExists(occupancy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employees"] = await _userManager.GetUsersInRoleAsync("Worker");
            ViewData["Workspaces"] = _context.Workspaces.ToList();
            ViewData["Rooms"] = _context.Rooms.ToList();
            return View(occupancy);
        }

        // GET: Occupancies/Delete/5
        [Authorize(Roles = "Office, Worker")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancies
                .Include(o => o.Employee)
                .Include(o => o.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occupancy == null)
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Worker") && occupancy.EmployeeId != currentUser.Id)
            {
                return Forbid();
            }

            return View(occupancy);
        }

        // POST: Occupancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Office, Worker")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occupancy = await _context.Occupancies.FindAsync(id);
            var currentUser = await _userManager.GetUserAsync(User);

            if (occupancy == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Worker") && occupancy.EmployeeId != currentUser.Id)
            {
                return Forbid();
            }

            _context.Occupancies.Remove(occupancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccupancyExists(int id)
        {
            return _context.Occupancies.Any(e => e.Id == id);
        }

        public IActionResult WeeklyOccupancyPreview()
        {
            // Calculate the start of the current week
            DateTime startOfWeek = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek);
            // Calculate the end of the current week
            DateTime endOfWeek = startOfWeek.AddDays(6);

            var occupancies = _context.Occupancies
                                    .Include(o => o.Employee)
                                    .Include(o => o.Room)
                                    .Where(o => o.Date >= startOfWeek && o.Date <= endOfWeek)
                                    .OrderBy(o => o.Date)
                                    .ToList();

            var viewModel = new WeeklyOccupancyViewModel
            {
                WeekStartDate = startOfWeek,
                WeekEndDate = endOfWeek,
                Occupancies = occupancies
            };

            return View("WeeklyOccupancy", viewModel);
        }

        private async Task<bool> IsWorkspaceOccupiedAsync(int? workspaceId, DateTime date)
        {
            if (workspaceId != null && workspaceId < 0)
                return false;
            var existingOccupancy = await _context.Occupancies
                                                  .FirstOrDefaultAsync(o => o.WorkspaceId == workspaceId && o.Date == date);
            return existingOccupancy != null;
        }

        private IActionResult CustomForbid(string message)
        {
            return new ContentResult
            {
                Content = message,
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.Forbidden
            };
        }
    }

}
