﻿using System;
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
    public class Request_Mental_HealthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Request_Mental_HealthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Request_Mental_Health
        public async Task<IActionResult> Index()
        {
            return View(await _context.Request_Mental_Health.ToListAsync());
        }

        // GET: Request_Mental_Health/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request_Mental_Health = await _context.Request_Mental_Health
                .FirstOrDefaultAsync(m => m.ID == id);
            if (request_Mental_Health == null)
            {
                return NotFound();
            }

            return View(request_Mental_Health);
        }

        // GET: Request_Mental_Health/Create
        [Authorize]
        //this "Authorize" keyword is requried so that the person has to login before entering the data on the form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Request_Mental_Health/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName", "Date")] Request_Mental_Health request_Mental_Health)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request_Mental_Health);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request_Mental_Health);
        }

        // GET: Request_Mental_Health/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request_Mental_Health = await _context.Request_Mental_Health.FindAsync(id);
            if (request_Mental_Health == null)
            {
                return NotFound();
            }
            return View(request_Mental_Health);
        }

        // POST: Request_Mental_Health/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName", "Date")] Request_Mental_Health request_Mental_Health)
        {
            if (id != request_Mental_Health.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request_Mental_Health);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Request_Mental_HealthExists(request_Mental_Health.ID))
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
            return View(request_Mental_Health);
        }

        // GET: Request_Mental_Health/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request_Mental_Health = await _context.Request_Mental_Health
                .FirstOrDefaultAsync(m => m.ID == id);
            if (request_Mental_Health == null)
            {
                return NotFound();
            }

            return View(request_Mental_Health);
        }

        // POST: Request_Mental_Health/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request_Mental_Health = await _context.Request_Mental_Health.FindAsync(id);
            _context.Request_Mental_Health.Remove(request_Mental_Health);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Request_Mental_HealthExists(int id)
        {
            return _context.Request_Mental_Health.Any(e => e.ID == id);
        }
    }
}
