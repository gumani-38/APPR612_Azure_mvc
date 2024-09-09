using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR612_Activity2.Data;
using APPR612_Activity2.Models;

namespace APPR612_Activity2.Controllers
{
    public class DJsController : Controller
    {
        private readonly DJContext _context;

        public DJsController(DJContext context)
        {
            _context = context;
        }

        // GET: DJs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DJ.ToListAsync());
        }

        // GET: DJs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dJ = await _context.DJ
                .FirstOrDefaultAsync(m => m.DJID == id);
            if (dJ == null)
            {
                return NotFound();
            }

            return View(dJ);
        }

        // GET: DJs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DJs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DJID,stageName")] DJ dJ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dJ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dJ);
        }

        // GET: DJs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dJ = await _context.DJ.FindAsync(id);
            if (dJ == null)
            {
                return NotFound();
            }
            return View(dJ);
        }

        // POST: DJs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DJID,stageName")] DJ dJ)
        {
            if (id != dJ.DJID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dJ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DJExists(dJ.DJID))
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
            return View(dJ);
        }

        // GET: DJs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dJ = await _context.DJ
                .FirstOrDefaultAsync(m => m.DJID == id);
            if (dJ == null)
            {
                return NotFound();
            }

            return View(dJ);
        }

        // POST: DJs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dJ = await _context.DJ.FindAsync(id);
            if (dJ != null)
            {
                _context.DJ.Remove(dJ);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DJExists(int id)
        {
            return _context.DJ.Any(e => e.DJID == id);
        }
    }
}
