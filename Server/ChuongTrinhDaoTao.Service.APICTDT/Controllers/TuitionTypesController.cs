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
    public class TuitionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuitionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TuitionTypes
        public async Task<IActionResult> Index()
        {
              return _context.tuitionTypes != null ? 
                          View(await _context.tuitionTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.tuitionTypes'  is null.");
        }

        // GET: TuitionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.tuitionTypes
                .FirstOrDefaultAsync(m => m.TuitionTypeId == id);
            if (tuitionType == null)
            {
                return NotFound();
            }

            return View(tuitionType);
        }

        // GET: TuitionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TuitionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuitionTypeId,TuitionTypename")] TuitionType tuitionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuitionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuitionType);
        }

        // GET: TuitionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.tuitionTypes.FindAsync(id);
            if (tuitionType == null)
            {
                return NotFound();
            }
            return View(tuitionType);
        }

        // POST: TuitionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuitionTypeId,TuitionTypename")] TuitionType tuitionType)
        {
            if (id != tuitionType.TuitionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuitionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuitionTypeExists(tuitionType.TuitionTypeId))
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
            return View(tuitionType);
        }

        // GET: TuitionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tuitionTypes == null)
            {
                return NotFound();
            }

            var tuitionType = await _context.tuitionTypes
                .FirstOrDefaultAsync(m => m.TuitionTypeId == id);
            if (tuitionType == null)
            {
                return NotFound();
            }

            return View(tuitionType);
        }

        // POST: TuitionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tuitionTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tuitionTypes'  is null.");
            }
            var tuitionType = await _context.tuitionTypes.FindAsync(id);
            if (tuitionType != null)
            {
                _context.tuitionTypes.Remove(tuitionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuitionTypeExists(int id)
        {
          return (_context.tuitionTypes?.Any(e => e.TuitionTypeId == id)).GetValueOrDefault();
        }
    }
}
