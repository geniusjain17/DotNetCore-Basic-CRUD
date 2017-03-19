using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSys.Data;
using ParkingSys.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParkingSys.Controllers
{
    [Authorize]
    public class VechilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VechilesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Vechiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vechile.ToListAsync());
        }

        // GET: Vechiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vechile = await _context.Vechile.SingleOrDefaultAsync(m => m.Id == id);
            if (vechile == null)
            {
                return NotFound();
            }

            return View(vechile);
        }

        // GET: Vechiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vechiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverName,EntryDate,InTime,OutTime,VechileType")] Vechile vechile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vechile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vechile);
        }

        // GET: Vechiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vechile = await _context.Vechile.SingleOrDefaultAsync(m => m.Id == id);
            if (vechile == null)
            {
                return NotFound();
            }
            return View(vechile);
        }

        // POST: Vechiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DriverName,EntryDate,InTime,OutTime,VechileType")] Vechile vechile)
        {
            if (id != vechile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vechile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VechileExists(vechile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(vechile);
        }

        // GET: Vechiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vechile = await _context.Vechile.SingleOrDefaultAsync(m => m.Id == id);
            if (vechile == null)
            {
                return NotFound();
            }

            return View(vechile);
        }

        // POST: Vechiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vechile = await _context.Vechile.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vechile.Remove(vechile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VechileExists(int id)
        {
            return _context.Vechile.Any(e => e.Id == id);
        }
    }
}
