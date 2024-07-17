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
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DepartmentsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            const int length = 20;

            ViewData["From"] = length;
            ViewData["Length"] = length;
            ViewData["More"] = _context.Departments.Count() > length;
            return View(await _context.Departments.Include(d => d.Chief).Take(length).ToListAsync());
        }

        // GET: Departments (PartialView)
        public async Task<IActionResult> GetDepartments(int from, int length)
        {
            ViewData["From"] = from + length;
            ViewData["Length"] = length;
            ViewData["More"] = _context.Departments.Count() > from + length;

            return PartialView("IndexPartial", await _context.Departments.Include(d => d.Chief).Skip(from).Take(length).ToListAsync());
        }

        // GET: Departments/Create
        [Authorize(Roles = "Administrator, Office")]
        public async Task<IActionResult> Create()
        {
            ViewData["Chiefs"] = await _userManager.GetUsersInRoleAsync("Chief");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ChiefId")] Department department)
        {
            department.Chief = await _userManager.FindByIdAsync(department.ChiefId);
            if (department.Chief == null)
            {
                Console.WriteLine("Chief cannot be null");
            }
            else
            {
                Console.WriteLine(department.Chief.UserName);
                ModelState.Remove("Chief");
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("we actually got here." + department.Name + "  " + department.ChiefId);
                _context.Add(department);
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
                ViewData["Users"] = _userManager.Users.ToList();
                return View(department);
            }
        }

        // GET: Department/Edit/5
        [Authorize(Roles = "Administrator, Office")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["Chiefs"] = await _userManager.GetUsersInRoleAsync("Chief");
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ChiefId")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            department.Chief = await _userManager.FindByIdAsync(department.ChiefId);
            if (department.Chief == null)
            {
                Console.WriteLine("Chief cannot be null");
            }
            else
            {
                Console.WriteLine(department.Chief.UserName);
                ModelState.Remove("Chief");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            ViewData["Chiefs"] = await _userManager.GetUsersInRoleAsync("Chief");
            return View(department);
        }

        // GET: Departments/Delete/5
        [Authorize(Roles = "Administrator, Office")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'MyContext.Department'  is null.");
            }
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
