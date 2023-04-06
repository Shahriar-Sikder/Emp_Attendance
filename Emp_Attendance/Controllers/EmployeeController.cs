using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emp_Attendance.Data;
using Emp_Attendance.Models;
using Microsoft.AspNetCore.Authorization;

namespace Emp_Attendance.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'EmployeeDbContext.Employees'  is null.");
        }

        // GET: Employee/Details/5
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var emp_Details = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emp_Details == null)
            {
                return NotFound();
            }

            return View(emp_Details);
        }

        // GET: Employee/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("Id,Name,Designation,BirthDate,JoiningDate,Address,PhoneNo,Salary")] Emp_Details emp_Details)
        {
            if (ModelState.IsValid)
            {
                emp_Details.Id = Guid.NewGuid();
                _context.Add(emp_Details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp_Details);
        }

        // GET: Employee/Edit/5
        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var emp_Details = await _context.Employees.FindAsync(id);
            if (emp_Details == null)
            {
                return NotFound();
            }
            return View(emp_Details);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Designation,BirthDate,JoiningDate,Address,PhoneNo,Salary")] Emp_Details emp_Details)
        {
            if (id != emp_Details.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp_Details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Emp_DetailsExists(emp_Details.Id))
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
            return View(emp_Details);
        }

        // GET: Employee/Delete/5
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var emp_Details = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emp_Details == null)
            {
                return NotFound();
            }

            return View(emp_Details);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'EmployeeDbContext.Employees'  is null.");
            }
            var emp_Details = await _context.Employees.FindAsync(id);
            if (emp_Details != null)
            {
                _context.Employees.Remove(emp_Details);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Emp_DetailsExists(Guid id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
