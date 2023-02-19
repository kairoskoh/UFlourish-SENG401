using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;

namespace JokesWebApp.Controllers
{
    public class UserPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserPayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserPayment.Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserPayments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.CardNumber == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // GET: UserPayments/Create
        public IActionResult Create(int Id)
        {
            var UserPayment=new UserPayment()
            {
                UserId= Id,
            };
            return View(UserPayment);
        }

        // POST: UserPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardNumber,ExpiryDate,UserId")] UserPayment userPayment)
        {
          
            if (ModelState.IsValid)
            {
                _context.Add(userPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","UserBasicInfoes");
            }
         
            return View(userPayment);
        }

        // GET: UserPayments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment.FindAsync(id);
            if (userPayment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserBasicInfoes, "Id", "Id", userPayment.UserId);
            return View(userPayment);
        }

        // POST: UserPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CardNumber,ExpiryDate,UserId")] UserPayment userPayment)
        {
            if (id != userPayment.CardNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaymentExists(userPayment.CardNumber))
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
            ViewData["UserId"] = new SelectList(_context.UserBasicInfoes, "Id", "Id", userPayment.UserId);
            return View(userPayment);
        }

        // GET: UserPayments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayment
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.CardNumber == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // POST: UserPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userPayment = await _context.UserPayment.FindAsync(id);
            _context.UserPayment.Remove(userPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaymentExists(string id)
        {
            return _context.UserPayment.Any(e => e.CardNumber == id);
        }
    }
}
