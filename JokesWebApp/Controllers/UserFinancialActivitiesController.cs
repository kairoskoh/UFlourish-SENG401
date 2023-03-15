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
    public class UserFinancialActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFinancialActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: UserFinancialActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserFinancialActivity.ToListAsync());
        }
        [Authorize]
        // GET: UserFinancialActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFinancialActivity = await _context.UserFinancialActivity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFinancialActivity == null)
            {
                return NotFound();
            }

            return View(userFinancialActivity);
        }
        [Authorize]
        // GET: UserFinancialActivities/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: UserFinancialActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TransactionName,TransactionType,PostedDate,Term,Charge,Payment,Refund")] UserFinancialActivity userFinancialActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFinancialActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFinancialActivity);
        }
        [Authorize]
        // GET: UserFinancialActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFinancialActivity = await _context.UserFinancialActivity.FindAsync(id);
            if (userFinancialActivity == null)
            {
                return NotFound();
            }
            return View(userFinancialActivity);
        }
        [Authorize]
        // POST: UserFinancialActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TransactionName,TransactionType,PostedDate,Term,Charge,Payment,Refund")] UserFinancialActivity userFinancialActivity)
        {
            if (id != userFinancialActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFinancialActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFinancialActivityExists(userFinancialActivity.Id))
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
            return View(userFinancialActivity);
        }
        [Authorize]
        // GET: UserFinancialActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFinancialActivity = await _context.UserFinancialActivity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFinancialActivity == null)
            {
                return NotFound();
            }

            return View(userFinancialActivity);
        }
        [Authorize]
        // POST: UserFinancialActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFinancialActivity = await _context.UserFinancialActivity.FindAsync(id);
            _context.UserFinancialActivity.Remove(userFinancialActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFinancialActivityExists(int id)
        {
            return _context.UserFinancialActivity.Any(e => e.Id == id);
        }
    }
}
