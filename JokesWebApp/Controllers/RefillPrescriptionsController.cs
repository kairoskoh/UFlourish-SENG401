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

        public string adminEmail = "admin123@gmail.com";

        public int status = -1;

        public RefillPrescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefillPrescriptions
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            

            //var user = _context.UserBasicInfoes.Where(x => x.Email == userEmail).FirstOrDefault();

            ViewData["email"] = userEmail;


            if (userEmail.Equals(adminEmail))
            {
                return View(await _context.RefillPrescriptions.ToListAsync());
            }
            else
            {
                return View(await _context.RefillPrescriptions.Where(j => j.UserName.Contains(userEmail)).ToListAsync());
            }
            
        }

        // GET: RefillPrescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;

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
        [Authorize]
        public IActionResult Create()
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;
            return View();
        }

        // POST: RefillPrescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,MedicineName,RequestRefillDate")] RefillPrescriptions refillPrescriptions)
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;

            if (ModelState.IsValid)
            {
                _context.Add(refillPrescriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refillPrescriptions);
        }

        // GET: RefillPrescriptions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;

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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicineName,RefillDate")] RefillPrescriptions refillPrescriptions)
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;

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
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            string userEmail = User.Identity.Name;
            //gives the current logged in user name
            //Debug.WriteLine(userEmail);
            //return it to main page
            ViewData["email"] = userEmail;

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
        [Authorize]
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


        public void setStatus(int i)
        {
            status = i;
        }

        public int getStatus()
        {
            return status;
        }

    }
}
