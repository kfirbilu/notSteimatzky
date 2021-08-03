using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Controllers
{
    public class CreditCardsController : Controller
    {
        private readonly BooksStoreContext _context;

        public CreditCardsController(BooksStoreContext context)
        {
            _context = context;
        }

        // GET: CreditCards
        public async Task<IActionResult> Index()
        {
            var booksStoreContext = _context.CreditCard.Include(c => c.User);
            return View(await booksStoreContext.ToListAsync());
        }

        // GET: CreditCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // GET: CreditCards/Create
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(_context.Set<User>(), "Id", "Address");
            return View();
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OwnerName,Number,ExpirationMonth,ExpirationYear,CVV,UserId")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID"] = new SelectList(_context.Set<User>(), "Id", "Address", creditCard.ID);
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.Set<User>(), "Id", "Address", creditCard.ID);
            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OwnerName,Number,ExpirationMonth,ExpirationYear,CVV,UserId")] CreditCard creditCard)
        {
            if (id != creditCard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardExists(creditCard.ID))
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
            ViewData["ID"] = new SelectList(_context.Set<User>(), "Id", "Address", creditCard.ID);
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCard = await _context.CreditCard.FindAsync(id);
            _context.CreditCard.Remove(creditCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCard.Any(e => e.ID == id);
        }
    }
}
