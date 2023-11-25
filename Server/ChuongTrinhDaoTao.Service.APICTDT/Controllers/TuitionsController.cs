using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChuongTrinhDaoTao.Service.APICTDT.Data;
using ChuongTrinhDaoTao.Service.APICTDT.Models;

namespace ChuongTrinhDaoTao.Service.APICTDT.Controllers
{
    public class TuitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tuitions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tuitions.Include(t => t.tuitionType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tuitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tuitions == null)
            {
                return NotFound();
            }

            var tuition = await _context.tuitions
                .Include(t => t.tuitionType)
                .FirstOrDefaultAsync(m => m.TuitionTypeId == id);
            if (tuition == null)
            {
                return NotFound();
            }

            return View(tuition);
        }

        // GET: Tuitions/Create
        public IActionResult Create()
        {
            ViewData["TuitionTypeId"] = new SelectList(_context.tuitionTypes, "TuitionTypeId", "TuitionTypename");
            return View();
        }

        // POST: Tuitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuitionId,TuitionName,TuitionDescription,Price,TuitionTypeId")] Tuition tuition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TuitionTypeId"] = new SelectList(_context.tuitionTypes, "TuitionTypeId", "TuitionTypename", tuition.TuitionTypeId);
            return View(tuition);
        }

        // GET: Tuitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tuitions == null)
            {
                return NotFound();
            }

            var tuition = await _context.tuitions.FindAsync(id);
            if (tuition == null)
            {
                return NotFound();
            }
            ViewData["TuitionTypeId"] = new SelectList(_context.tuitionTypes, "TuitionTypeId", "TuitionTypename", tuition.TuitionTypeId);
            return View(tuition);
        }

        // POST: Tuitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuitionId,TuitionName,TuitionDescription,Price,TuitionTypeId")] Tuition tuition)
        {
            if (id != tuition.TuitionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuitionExists(tuition.TuitionTypeId))
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
            ViewData["TuitionTypeId"] = new SelectList(_context.tuitionTypes, "TuitionTypeId", "TuitionTypename", tuition.TuitionTypeId);
            return View(tuition);
        }

        // GET: Tuitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tuitions == null)
            {
                return NotFound();
            }

            var tuition = await _context.tuitions
                .Include(t => t.tuitionType)
                .FirstOrDefaultAsync(m => m.TuitionTypeId == id);
            if (tuition == null)
            {
                return NotFound();
            }

            return View(tuition);
        }

        // POST: Tuitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tuitions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tuitions'  is null.");
            }
            var tuition = await _context.tuitions.FindAsync(id);
            if (tuition != null)
            {
                _context.tuitions.Remove(tuition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuitionExists(int id)
        {
          return (_context.tuitions?.Any(e => e.TuitionTypeId == id)).GetValueOrDefault();
        }
    }
}
