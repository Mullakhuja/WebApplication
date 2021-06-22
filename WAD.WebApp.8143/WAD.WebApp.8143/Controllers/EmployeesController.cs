using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.DAL.DBO;

namespace WAD.WebApp._8143.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly PaperCompDbContext _context;

        public EmployeesController(PaperCompDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var paperCompDbContext = _context.Employee.Include(e => e.Branch);
            return View(await paperCompDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branch, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Birthday,Gender,Salary,Email,EmpPhoto,IsFullTime,BranchId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                byte[] photoBytes = null;
                if (employee.EmpPhoto != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        employee.EmpPhoto.CopyTo(memory);
                        photoBytes = memory.ToArray();
                    }
                }
                employee.EmpPhotoBinary = photoBytes;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branch, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branch, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Birthday,Gender,Salary,Email,EmpPhotoBinary,EmpPhoto,IsFullTime,BranchId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] photoBytes = null;
                    if (employee.EmpPhoto != null)
                    {
                        using (var memory = new MemoryStream())
                        {
                            employee.EmpPhoto.CopyTo(memory);
                            photoBytes = memory.ToArray();
                        }
                    }
                    else
                    {
                        photoBytes = employee.EmpPhotoBinary;
                    }
                    employee.EmpPhotoBinary = photoBytes;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["BranchId"] = new SelectList(_context.Branch, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }

        public async Task<IActionResult> ShowImage(int? id)
        {
            if (id.HasValue)
            {
                var employee = await _context.Employee.FindAsync(id);
                if (employee?.EmpPhotoBinary != null)
                {
                    return File(
                        employee.EmpPhotoBinary,
                        "image/jpeg",
                        $"emp_{id}.jpg");
                }
            }

            return NotFound();
        }
    }
}
