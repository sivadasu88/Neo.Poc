using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;
using Neo.Poc.Models;

namespace Neo.Poc.Controllers
{
    public class NeoTestsController : Controller
    {
        private readonly RegistrationContext _context;

        public NeoTestsController(RegistrationContext context)
        {
            _context = context;
        }

        // GET: neoTests
        public async Task<IActionResult> Index()
        {
            return View(await _context.NeoTests.ToListAsync());
        }

        // GET: neoTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neoTest = await _context.NeoTests
                .FirstOrDefaultAsync(m => m.NeoTestId == id);
            if (neoTest == null)
            {
                return NotFound();
            }

            return View(neoTest);
        }

        // GET: neoTests/Create
        public IActionResult Create()
        {
            return View(new NeoTest());
        }

        // POST: neoTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NeoTest neoTest)
        {
            if (ModelState.IsValid)
            {
                _context.NeoTests.Add(neoTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neoTest);
        }

        // GET: neoTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neoTest = await _context.NeoTests.FindAsync(id);
            if (neoTest == null)
            {
                return NotFound();
            }
            return View(neoTest);
        }

        // POST: neoTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] NeoTest neoTest)
        {
            if (id != neoTest.NeoTestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neoTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!neoTestExists(neoTest.NeoTestId))
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
            return View(neoTest);
        }

        // GET: neoTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neoTest = await _context.NeoTests
                .FirstOrDefaultAsync(m => m.NeoTestId == id);
            if (neoTest == null)
            {
                return NotFound();
            }

            return View(neoTest);
        }

        // POST: neoTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neoTest = await _context.NeoTests.FindAsync(id);
            _context.NeoTests.Remove(neoTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool neoTestExists(int id)
        {
            return _context.NeoTests.Any(e => e.NeoTestId == id);
        }
    }
}
