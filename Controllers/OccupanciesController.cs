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


namespace Deskbuddy.Controllers
{
    [Authorize(Roles ="Office, Chief, Worker,Administrator")]
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
        [Authorize(Roles = "Office, Worker, Administrator")]
        public IActionResult Create()
        {

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            ViewData["RoomType"] = new SelectList(_context.Rooms, "Id", "Type");
            return View();
        }

        // POST: Occupancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,EmployeeId,Date,Type")] Occupancy occupancy)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            occupancy.UserId = currentUser.Id;

            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", occupancy.RoomId);
            ViewData["RoomType"] = new SelectList(_context.Rooms, "Id", "Type", occupancy.RoomId);
            return View(occupancy);
        }
        [Authorize(Roles ="Office, Worker")]
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
                if (occupancy.UserId != currentUser.Id)
                {
                    // If the current user is not allowed to edit this occupancy, return an unauthorized view or handle accordingly
                    return Forbid();
                }
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", occupancy.RoomId);
            ViewData["RoomType"] = new SelectList(_context.Rooms, "Id", "Type", occupancy.RoomId);
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

            if (User.IsInRole("Worker") && existingOccupancy.UserId != currentUser.Id)
            {
                return Forbid();
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
            ViewData["RoomType"] = new SelectList(_context.Rooms, "Id", "Type", occupancy.RoomId);
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

            if (User.IsInRole("Worker") && occupancy.UserId != currentUser.Id)
            {
                return Forbid();
            }

            return View(occupancy);
        }

        // POST: Occupancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Office, Worker")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occupancy = await _context.Occupancies.FindAsync(id);
            var currentUser = await _userManager.GetUserAsync(User);

            if (occupancy == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Worker") && occupancy.UserId != currentUser.Id)
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
    }
}
