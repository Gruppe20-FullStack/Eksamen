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
    public class OrganisasjonerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisasjonerController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
        // GET: Organisasjoner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organisasjoner.ToListAsync());
        }
        */

        public async Task<IActionResult> Index()
        {
            var data = _context.Organisasjoner
                .Include(o => o.RollePersoner);

            return View(await data.ToListAsync());
        }


        // GET: Organisasjoner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisasjon = await _context.Organisasjoner
                .Include(o => o.RollePersoner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisasjon == null)
            {
                return NotFound();
            }

            return View(organisasjon);
        }

        // GET: Organisasjoner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisasjoner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Organisasjonsnummer,Organisasjonsform")] Organisasjon organisasjon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisasjon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organisasjon);
        }

        // GET: Organisasjoner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisasjon = await _context.Organisasjoner.FindAsync(id);
            if (organisasjon == null)
            {
                return NotFound();
            }
            return View(organisasjon);
        }

        // POST: Organisasjoner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,Organisasjonsnummer,Organisasjonsform")] Organisasjon organisasjon)
        {
            if (id != organisasjon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisasjon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisasjonExists(organisasjon.Id))
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
            return View(organisasjon);
        }

        // GET: Organisasjoner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisasjon = await _context.Organisasjoner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisasjon == null)
            {
                return NotFound();
            }

            return View(organisasjon);
        }

        // POST: Organisasjoner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisasjon = await _context.Organisasjoner.FindAsync(id);
            if (organisasjon != null)
            {
                _context.Organisasjoner.Remove(organisasjon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisasjonExists(int id)
        {
            return _context.Organisasjoner.Any(e => e.Id == id);
        }
    }
}
