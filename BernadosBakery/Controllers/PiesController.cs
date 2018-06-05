using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BernadosBakery.Data;
using BernadosBakery.Models;
using Microsoft.AspNetCore.Authorization;

namespace BernadosBakery.Controllers
{
    public class PiesController : Controller
    {
        private readonly BakeryContext _context;

        public PiesController(BakeryContext context)
        {
            _context = context;
        }

        // GET: Pies

            [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pie.ToListAsync());
        }

        [Authorize]
        // GET: Pies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pie.SingleOrDefaultAsync(m => m.Id == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // GET: Pies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortDesc,LongDesc,Price,SalePrice,ImageUrl,ImageThumbnailUrl,IsPieOfWeek")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pie);
        }

        // GET: Pies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pie.SingleOrDefaultAsync(m => m.Id == id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

        // POST: Pies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortDesc,LongDesc,Price,SalePrice,ImageUrl,ImageThumbnailUrl,IsPieOfWeek")] Pie pie)
        {
            if (id != pie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieExists(pie.Id))
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
            return View(pie);
        }

        // GET: Pies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pie
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pie = await _context.Pie.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pie.Remove(pie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieExists(int id)
        {
            return _context.Pie.Any(e => e.Id == id);
        }

       
    }
}
