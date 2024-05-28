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
            var beanSeanReservationDbContext = _context.Reservations.Include(r => r.Member).Include(r => r.Sitting).Include(r => r.Table);
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
                .Include(r => r.Member)
                .Include(r => r.Sitting)
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            ViewData["SittingId"] = new SelectList(_context.SittingSchedules, "SittingId", "SittingId");
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableId");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,SittingId,GuestName,Email,Phone,StartTime,Duration,NumOfGuests,ReservationSource,Notes,ReservationStatus,TableId,MemberId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.SittingSchedules, "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableId", reservation.TableId);
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.SittingSchedules, "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableId", reservation.TableId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,SittingId,GuestName,Email,Phone,StartTime,Duration,NumOfGuests,ReservationSource,Notes,ReservationStatus,TableId,MemberId")] Reservation reservation)
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.SittingSchedules, "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.RestaurantTables, "TableId", "TableId", reservation.TableId);
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
                .Include(r => r.Member)
                .Include(r => r.Sitting)
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
