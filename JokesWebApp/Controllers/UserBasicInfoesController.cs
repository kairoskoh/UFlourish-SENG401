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
    public class UserBasicInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserInsurancesController _userInsurancesController;
        public UserBasicInfoesController(ApplicationDbContext context,UserInsurancesController userInsurancesController)
        {
            _context = context;
            _userInsurancesController= userInsurancesController;
        }

        // GET: UserBasicInfoes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            var user= _context.UserBasicInfoes.Where(u => u.Email == userEmail).FirstOrDefault();
            _context.Entry(user).Collection(u=>u.Insurance).Load();
            
            return View(user);
        }


        // GET: UserBasicInfoes/Create
        [Authorize]
        public IActionResult Create()
        {
            var UserEmail = User.Identity.Name;
            ViewData["email"] = UserEmail;
            return View();
        }

        // POST: UserBasicInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BirthDate,Address,Phone,Email,FirstName,LastName")] UserBasicInfo userBasicInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBasicInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index","UserBasicInfoes");
            }
            return View(userBasicInfo);
        }

        // GET: UserBasicInfoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit()
        { 

            var userBasicInfo = await _context.UserBasicInfoes.Where(u=>u.Email==User.Identity.Name).FirstOrDefaultAsync();
            if (userBasicInfo == null)
            {
                return NotFound();
            }
            return View(userBasicInfo);
        }

        // POST: UserBasicInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BirthDate,Address,Phone,Email,FirstName,LastName")] UserBasicInfo userBasicInfo)
        {
            if (id != userBasicInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBasicInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBasicInfoExists(userBasicInfo.Id))
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
            return View(userBasicInfo);
        }

        // GET: UserBasicInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBasicInfo = await _context.UserBasicInfoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userBasicInfo == null)
            {
                return NotFound();
            }

            return View(userBasicInfo);
        }

        // POST: UserBasicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBasicInfo = await _context.UserBasicInfoes.FindAsync(id);
            _context.UserBasicInfoes.Remove(userBasicInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBasicInfoExists(int id)
        {
            return _context.UserBasicInfoes.Any(e => e.Id == id);
        }

        // method outside CRUD
        [Authorize]
        public IActionResult AddInsurance()
        {
            return _userInsurancesController.Create();
        }
        [Authorize]
        public IActionResult DeleteInsurance(int? Id)
        {
            var model = _context.UserBasicInfoes.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            var insurance=_context.UserInsurance.Where(u => u.Id == Id);
            return View("~/Views/UserInsurances/Delete.cshtml",insurance);
        }
    }



    
}
