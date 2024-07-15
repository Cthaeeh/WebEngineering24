using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Models;
using MyWebDbApp.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;
using MyWebDbApp.Areas.Identity.Data;

namespace MyWebDbApp.Controllers
{
    [Authorize(Roles = "Administrator, Office, Chief, Employee")]
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
            var occupancies = _context.Occupancies.Include(o => o.Employee).Include(o => o.Workspace);
            return View(await occupancies.ToListAsync());
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
                .Include(o => o.Workspace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        // GET: Occupancies/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["WorkplaceId"] = new SelectList(_context.Workspaces, "Id", "RoomId");
            return View();
        }

        // POST: Occupancies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkplaceId,EmployeeId,Date")] Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["WorkplaceId"] = new SelectList(_context.Workspaces, "Id", "RoomId");
            return View(occupancy);
        }

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

            // Check if the current user has the role "Mitarbeiter" and if the occupancy belongs to them
            var currentUser = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Sekretariat") && !User.IsInRole("Abteilungsleiter") && occupancy.EmployeeId != currentUser.Id)
            {
                return Forbid(); // Or handle unauthorized access
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", occupancy.EmployeeId);
            ViewData["WorkplaceId"] = new SelectList(_context.Workspaces, "Id", "RoomId", occupancy.WorkspaceId);
            return View(occupancy);
        }

        // POST: Occupancies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkplaceId,EmployeeId,Date")] Occupancy occupancy)
        {
            if (id != occupancy.Id)
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
            ViewData["WorkplaceId"] = new SelectList(_context.Workspaces, "Id", "RoomId", occupancy.WorkspaceId);
            return View(occupancy);
        }

        // GET: Occupancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancies
                .Include(o => o.Employee)
                .Include(o => o.Workspace)
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
    }
}