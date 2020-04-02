using LibraryApi.Domain;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class ReservationsController : Controller
    {
        LibraryDataContext Context;
        IWriteToTheReservationQueue ReservationQueue;

        public ReservationsController(LibraryDataContext context, IWriteToTheReservationQueue reservationQueue)
        {
            Context = context;
            ReservationQueue = reservationQueue;
        }

        [HttpPost("/reservations")]
        public async Task<ActionResult> AddReservation([FromBody] PostReservationRequest request)
        {
            //validate model
            //add to database
            var reservation = new Reservation
            {
                For = request.For,
                Books = string.Join(',', request.Books),
                ReservationCreated = DateTime.Now,
                Status = ReservationStatus.Pending
            };
            Context.Reservations.Add(reservation);
            await Context.SaveChangesAsync();

            //write message to queue (RabbitMQ)
            await ReservationQueue.Write(reservation);


            // return response
            return Ok(reservation);
        }

        [HttpGet("/reservations/approved")]
        public async Task<ActionResult> GetApprovedReservations()
        {
            var response = await Context.Reservations
            .Where(r => r.Status == ReservationStatus.Approved)
            .ToListAsync();
            // TODO: Project these into models. This is not a great way to do it. Classroom only.
            return Ok(response);
        }

        [HttpGet("/reservations/cancelled")]
        public async Task<ActionResult> GetCancelledReservations()
        {
            var response = await Context.Reservations
            .Where(r => r.Status == ReservationStatus.Cancelled)
            .ToListAsync();
            // TODO: Project these into models. This is not a great way to do it. Classroom only.
            return Ok(response);
        }

        [HttpGet("/reservations/pending")]
        public async Task<ActionResult> GetPendingReservations()
        {
            var response = await Context.Reservations
            .Where(r => r.Status == ReservationStatus.Pending)
            .ToListAsync();
            // TODO: Project these into models. This is not a great way to do it. Classroom only.
            return Ok(response);
        }
    }
}
