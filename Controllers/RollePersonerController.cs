using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gruppe20App.Data;
using Gruppe20App.Models;

namespace Gruppe20App.Controllers
{
    public class RollePersonerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RollePersonerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RollePersoner
        // ( Include() )
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RollePersoner.Include(r => r.Organisasjon);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RollePersoner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollePerson = await _context.RollePersoner
                .Include(r => r.Organisasjon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rollePerson == null)
            {
                return NotFound();
            }

            return View(rollePerson);
        }

        // GET: RollePersoner/Create
        public IActionResult Create()
        {
            ViewData["OrganisasjonId"] = new SelectList(_context.Organisasjoner, "Id", "Navn");
            return View();
        }

        // POST: RollePersoner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Rolle,OrganisasjonId")] RollePerson rollePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rollePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganisasjonId"] = new SelectList(_context.Organisasjoner, "Id", "Navn", rollePerson.OrganisasjonId);
            return View(rollePerson);
        }

        // GET: RollePersoner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollePerson = await _context.RollePersoner.FindAsync(id);
            if (rollePerson == null)
            {
                return NotFound();
            }
            ViewData["OrganisasjonId"] = new SelectList(_context.Organisasjoner, "Id", "Navn", rollePerson.OrganisasjonId);
            return View(rollePerson);
        }

        // POST: RollePersoner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,Rolle,OrganisasjonId")] RollePerson rollePerson)
        {
            if (id != rollePerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rollePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollePersonExists(rollePerson.Id))
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
            ViewData["OrganisasjonId"] = new SelectList(_context.Organisasjoner, "Id", "Navn", rollePerson.OrganisasjonId);
            return View(rollePerson);
        }

        // GET: RollePersoner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollePerson = await _context.RollePersoner
                .Include(r => r.Organisasjon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rollePerson == null)
            {
                return NotFound();
            }

            return View(rollePerson);
        }

        // POST: RollePersoner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rollePerson = await _context.RollePersoner.FindAsync(id);
            if (rollePerson != null)
            {
                _context.RollePersoner.Remove(rollePerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollePersonExists(int id)
        {
            return _context.RollePersoner.Any(e => e.Id == id);
        }
    }
}
