using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BernadosBakery.Data;
using BernadosBakery.Models;
using BernadosBakery.Operations;
using BernadosBakery.DTO;

namespace BernadosBakery.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly BakeryContext _context;

        public ReservationsController(BakeryContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {

            return View(await _context.Reservation.ToListAsync());
        }

        // GET: Reservations/Details/5
   
        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .SingleOrDefaultAsync(m => m.ID == id);

            GetAllGV mygetall = new GetAllGV();
            myReservations myReservations = new myReservations();

            DatabaseManager.GuestID = reservation.GuestId;

            myReservations.GuestId = reservation.GuestId;
            myReservations.ID = reservation.ID;
            myReservations.NumGuests = reservation.NumGuests;
            myReservations.DateTime = reservation.DateTime;
            myReservations.SeatingType = reservation.SeatingType;


            if (reservation == null)
            {
                return NotFound();
            }

            var allguests = _context.Guest.ToList();
            mygetall.guests = allguests;


            mygetall.myReservation = myReservations;

            return View(mygetall);


        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Reserve()
        {

            ViewData["Message"] = "Your application description page.";

            var dbguests = _context.Guest.ToList();
            var dbreservation = _context.Reservation.ToList();
           


            GetAllGV mygetall = new GetAllGV();

            mygetall.guests.AddRange(dbguests);
            mygetall.reservations.AddRange(dbreservation);


            return View(mygetall);
         
        }



        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GuestId,DateTime,NumGuests,SeatingType")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.SingleOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GuestId,DateTime,NumGuests,SeatingType")] Reservation reservation)
        {
            if (id != reservation.ID)
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
                    if (!ReservationExists(reservation.ID))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .SingleOrDefaultAsync(m => m.ID == id);
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
            var reservation = await _context.Reservation.SingleOrDefaultAsync(m => m.ID == id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ID == id);
        }

        public void FindGuest(int? id)

        {
            if (id == null)
            {

            }

            Guest guest = _context.Guest.SingleOrDefault(m => m.GuestId == DatabaseManager.GuestID);
            string name = guest.Name;
            string number = guest.PhoneNumber;

            DatabaseManager.GuestDetails = (name + " " + number + " ");

        }
    }
}
