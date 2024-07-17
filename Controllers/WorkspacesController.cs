using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Data;
using MyWebDbApp.Models;
using Microsoft.AspNetCore.Identity;
using MyWebDbApp.Areas.Identity.Data;

namespace MyWebDbApp.Controllers
{
    [Authorize]
    public class WorkspacesController : Controller
    {
        private readonly AppDbContext _context;

        public WorkspacesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
        }

        // GET: Workspaces
        [Authorize(Roles = "Sekretariat, Administrator")]
        public async Task<IActionResult> Index()
        {
            const int length = 20;

            ViewData["From"] = length;
            ViewData["Length"] = length;
            ViewData["More"] = _context.Workspaces.Count() > length;
            return View(await _context.Workspaces.Include(w => w.Room)
                                                 .Include(w => w.Equipment)
                                                 .Take(length)
                                                 .ToListAsync());
        }

        // GET: Workspaces (PartialView)
        public async Task<IActionResult> GetWorkspaces(int from, int length)
        {
            ViewData["From"] = from + length;
            ViewData["Length"] = length;
            ViewData["More"] = _context.Workspaces.Count() > from + length;

            return PartialView("IndexPartial", await _context.Workspaces.Include(w => w.Room)
                                                                        .Include(w => w.Equipment)
                                                                        .Skip(from)
                                                                        .Take(length).ToListAsync());
        }

        // GET: Workspaces/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["Rooms"] = _context.Rooms.ToList();
            return View();
        }

        // POST: Workspaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,RoomId")] Workspace workspace, string equipmentList)
        {
            workspace.Room = await _context.Rooms.FindAsync(workspace.RoomId);
            if (workspace.Room == null)
            {
                Console.WriteLine("Room cannot be null");
            }
            else
            {
                Console.WriteLine(workspace.Room.Name);
                ModelState.Remove("Room");
            }
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(equipmentList))
                {
                    var equipmentNames = equipmentList.Split(',').Select(e => e.Trim());
                    foreach (var equipmentName in equipmentNames)
                    {
                        workspace.Equipment.Add(new Equipment { Name = equipmentName });
                    }
                }
                _context.Add(workspace);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("Model is not valid");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // Log the error or inspect the message
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                ViewData["Rooms"] = _context.Rooms.ToList();
                return View(workspace);
            }
        }

        // GET: Workspaces/Edit/5
        [Authorize(Roles = "Administrator, Office")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workspaces == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspaces.Include(w => w.Equipment).FirstOrDefaultAsync(m => m.Id == id);
            if (workspace == null)
            {
                return NotFound();
            }
            ViewData["Rooms"] = _context.Rooms.ToList();
            return View(workspace);
        }

        // POST: Workspaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RoomId")] Workspace workspace, string equipmentList)
        {
            if (id != workspace.Id)
            {
                return NotFound();
            }
            workspace.Room = await _context.Rooms.FindAsync(workspace.RoomId);
            if (workspace.Room == null)
            {
                Console.WriteLine("Room cannot be null");
            }
            else
            {
                Console.WriteLine(workspace.Room.Name);
                ModelState.Remove("Room");
            }

            if (ModelState.IsValid)
            {
                var existingEquipment = _context.Equipment.Where(e => e.WorkspaceId == id);
                _context.Equipment.RemoveRange(existingEquipment);
                workspace.Equipment.Clear();
                if (!string.IsNullOrEmpty(equipmentList))
                {
                    var equipmentNames = equipmentList.Split(',').Select(e => e.Trim());
                    foreach (var equipmentName in equipmentNames)
                    {
                        workspace.Equipment.Add(new Equipment { Name = equipmentName });
                    }
                }
                try
                {
                    _context.Update(workspace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkspaceExists(workspace.Id))
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

            ViewData["Rooms"] = _context.Rooms.ToList();
            return View(workspace);
        }

        // GET: Workspaces/Delete/5
        [Authorize(Roles = "Administrator, Office")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workspaces == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workspace == null)
            {
                return NotFound();
            }

            return View(workspace);
        }

        // POST: Workspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workspaces == null)
            {
                return Problem("Entity set 'MyContext.Workspace'  is null.");
            }
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace != null)
            {
                _context.Workspaces.Remove(workspace);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkspaceExists(int id)
        {
            return _context.Workspaces.Any(e => e.Id == id);
        }
    }
}