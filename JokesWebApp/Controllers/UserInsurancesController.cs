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
    public class UserInsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserInsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserInsurances
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInsurance.ToListAsync());
        }

        // GET: UserInsurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInsurance = await _context.UserInsurance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInsurance == null)
            {
                return NotFound();
            }

            return View(userInsurance);
        }

        // GET: UserInsurances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInsurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,GroupNumber,PolicyNumber,CoPayAmount")] UserInsurance userInsurance)
        {
            var user = _context.UserBasicInfoes.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            if(user==null)
            {
                TempData["Message"] = "Please complete your user profile before we can process your insurance";
                return RedirectToAction("Create","UserBasicInfoes");
            }

            userInsurance.User= user;

            if (ModelState.IsValid)
            {
                _context.Add(userInsurance);
                await _context.SaveChangesAsync();
                Console.WriteLine("Create insurance is valid");
                return RedirectToAction("Index","UserBasicInfoes");
            }
            
           
            return View();
        }

        // GET: UserInsurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInsurance = await _context.UserInsurance.FindAsync(id);
            if (userInsurance == null)
            {
                return NotFound();
            }
            return View(userInsurance);
        }

        // POST: UserInsurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,GroupNumber,PolicyNumber,CoPayAmount")] UserInsurance userInsurance)
        {
            if (id != userInsurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInsurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInsuranceExists(userInsurance.Id))
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
            return View(userInsurance);
        }

        // GET: UserInsurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInsurance = await _context.UserInsurance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInsurance == null)
            {
                return NotFound();
            }

            return View(userInsurance);
        }

        // POST: UserInsurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInsurance = await _context.UserInsurance.FindAsync(id);
            _context.UserInsurance.Remove(userInsurance);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","UserBasicInfoes");
        }

        private bool UserInsuranceExists(int id)
        {
            return _context.UserInsurance.Any(e => e.Id == id);
        }
    }
}
