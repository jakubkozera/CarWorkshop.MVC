using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarWorkshop.MVC.Entities;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarWorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarWorkshops
        public async Task<IActionResult> Index()
        {
              return _context.CarWorkshops != null ? 
                          View(await _context.CarWorkshops.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CarWorkshops'  is null.");
        }

        // GET: CarWorkshops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarWorkshops == null)
            {
                return NotFound();
            }

            var carWorkshopEntity = await _context.CarWorkshops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carWorkshopEntity == null)
            {
                return NotFound();
            }

            return View(carWorkshopEntity);
        }

        // GET: CarWorkshops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarWorkshops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Desciption,Address,PhoneNumber")] CarWorkshopEntity carWorkshopEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carWorkshopEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carWorkshopEntity);
        }

        // GET: CarWorkshops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarWorkshops == null)
            {
                return NotFound();
            }

            var carWorkshopEntity = await _context.CarWorkshops.FindAsync(id);
            if (carWorkshopEntity == null)
            {
                return NotFound();
            }
            return View(carWorkshopEntity);
        }

        // POST: CarWorkshops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desciption,Address,PhoneNumber")] CarWorkshopEntity carWorkshopEntity)
        {
            if (id != carWorkshopEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carWorkshopEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarWorkshopEntityExists(carWorkshopEntity.Id))
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
            return View(carWorkshopEntity);
        }

        // GET: CarWorkshops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarWorkshops == null)
            {
                return NotFound();
            }

            var carWorkshopEntity = await _context.CarWorkshops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carWorkshopEntity == null)
            {
                return NotFound();
            }

            return View(carWorkshopEntity);
        }

        // POST: CarWorkshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarWorkshops == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarWorkshops'  is null.");
            }
            var carWorkshopEntity = await _context.CarWorkshops.FindAsync(id);
            if (carWorkshopEntity != null)
            {
                _context.CarWorkshops.Remove(carWorkshopEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarWorkshopEntityExists(int id)
        {
          return (_context.CarWorkshops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
