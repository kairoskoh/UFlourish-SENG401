using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace JokesWebApp.Controllers
{
    public class RefillPrescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefillPrescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefillPrescriptions
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefillPrescriptions.ToListAsync());
        }

        // GET: RefillPrescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refillPrescriptions = await _context.RefillPrescriptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refillPrescriptions == null)
            {
                return NotFound();
            }

            return View(refillPrescriptions);
        }

        // GET: RefillPrescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefillPrescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicineName,RefillDate")] RefillPrescriptions refillPrescriptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refillPrescriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refillPrescriptions);
        }

        // GET: RefillPrescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refillPrescriptions = await _context.RefillPrescriptions.FindAsync(id);
            if (refillPrescriptions == null)
            {
                return NotFound();
            }
            return View(refillPrescriptions);
        }

        // POST: RefillPrescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicineName,RefillDate")] RefillPrescriptions refillPrescriptions)
        {
            if (id != refillPrescriptions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refillPrescriptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefillPrescriptionsExists(refillPrescriptions.Id))
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
            return View(refillPrescriptions);
        }

        // GET: RefillPrescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refillPrescriptions = await _context.RefillPrescriptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refillPrescriptions == null)
            {
                return NotFound();
            }

            return View(refillPrescriptions);
        }

        // POST: RefillPrescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refillPrescriptions = await _context.RefillPrescriptions.FindAsync(id);
            _context.RefillPrescriptions.Remove(refillPrescriptions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefillPrescriptionsExists(int id)
        {
            return _context.RefillPrescriptions.Any(e => e.Id == id);
        }
    }
}
