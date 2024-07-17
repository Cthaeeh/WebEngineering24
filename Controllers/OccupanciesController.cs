using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deskbuddy.Data;
using Deskbuddy.Models;
using Microsoft.AspNetCore.Identity;
using Deskbuddy.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Deskbuddy.Controllers
{
    [Authorize(Roles ="Sekretariat, Abteilungsleiter, Mitarbeiter")]
    public class OccupanciesController : Controller
    {
        private readonly DeskbuddyContext _context;
        private readonly UserManager<DeskbuddyUser> _userManager;

        public OccupanciesController(DeskbuddyContext context, UserManager<DeskbuddyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Occupancies
        public async Task<IActionResult> Index()
        {
            var deskbuddyContext = _context.Occupancies.Include(o => o.Employee).Include(o => o.Room);
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        // GET: Occupancies/Create
        [Authorize(Roles = "Sekretariat")]
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        // POST: Occupancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,EmployeeId,Date,Features")] Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", occupancy.RoomId);
            return View(occupancy);
        }
        [Authorize(Roles ="Sekretariat, Mitarbeiter")]
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
            var existingOccupancy = await _context.Occupancies.FindAsync(id);

            if (existingOccupancy == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Mitarbeiter"))
            {

                // Check if the current user can edit the specified occupancy
                if (existingOccupancy.UserId != currentUser.Id)
                {
                    // If the current user is not allowed to edit this occupancy, return an unauthorized view or handle accordingly
                    return Forbid();
                }

                // If the current user is allowed to edit, proceed to show the edit view
                return View(existingOccupancy);
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", occupancy.RoomId);
            return View(occupancy);
        }

        // POST: Occupancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomId,EmployeeId,Date,Features")] Occupancy occupancy)
        {
            if (id != occupancy.Id)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var existingOccupancy = await _context.Occupancies.FindAsync(id);

            if (existingOccupancy == null)
            {
                return NotFound();
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", occupancy.RoomId);
            return View(occupancy);
        }

        // GET: Occupancies/Delete/5
        [Authorize(Roles = "Sektretariat")]
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

            return View(occupancy);
        }

        // POST: Occupancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occupancy = await _context.Occupancies.FindAsync(id);
            if (occupancy != null)
            {
                _context.Occupancies.Remove(occupancy);
            }

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

            return View("WeeklyOccupancyViewModel", viewModel);
        }
    }
}
