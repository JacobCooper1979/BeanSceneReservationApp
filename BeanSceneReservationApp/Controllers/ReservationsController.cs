using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneReservationApp.Models;

namespace BeanSceneReservationApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly BeanSeanReservationDbContext _context;

        public ReservationsController(BeanSeanReservationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var beanSeanReservationDbContext = _context.Reservations.Include(r => r.Table);
            return View(await beanSeanReservationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Table)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,GuestName,Email,Phone,StartTime,NumOfGuests,Notes,OrderSource,ReservationStatus,SittingTime,AreaName,TableId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Check if the table exists in the database
                var table = await _context.RestaurantTables.Include(t => t.Area).FirstOrDefaultAsync(t => t.TableId == reservation.TableId);
                if (table == null)
                {
                    return NotFound(); // Table not found
                }

                // Check if the selected table is in the same area as the customer's selected area
                if (table.AreaName != reservation.AreaName)
                {
                    ModelState.AddModelError("TableId", "The selected table is not in the same area as the customers selected area.");
                    ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName", reservation.TableId);
                    return View(reservation);
                }

                // Check if the table is already booked out
                if (table.TableStatus == TableStatus.BookedOut)
                {
                    ModelState.AddModelError("TableId", "The selected table is already booked out.");
                    ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName", reservation.TableId);
                    return View(reservation);
                }

                // Setting reservations to pending once they are created
                reservation.ReservationStatus = ReservationStatus.Pending;

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                // Update the table status to Reserved
                table.TableStatus = TableStatus.BookedOut;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName", reservation.TableId);
            return View(reservation);
        }


        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName", reservation.TableId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,GuestName,Email,Phone,StartTime,NumOfGuests,Notes,OrderSource,ReservationStatus,SittingTime,AreaName,TableId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableName", reservation.TableId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Table)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
