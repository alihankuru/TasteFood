using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();


        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateReservation()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }



        [HttpPost]
        public ActionResult UpdateReservationStatus(int id, string status)
        {
            var reservation = context.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.ReservationStatus = status;
                context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }



        public ActionResult DeleteReservation(int id)
        {
            var values = context.Reservations.Find(id);
            context.Reservations.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }



        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }


        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var value = context.Reservations.Find(reservation.ReservationId);
            value.Name = reservation.Name;
            value.Email = reservation.Email;
            value.Phone = reservation.Phone;
            value.ReservationDate = reservation.ReservationDate;
            value.Time = reservation.Time;
            value.GuestCount = reservation.GuestCount;
            value.ReservationStatus = reservation.ReservationStatus;

            context.SaveChanges();

            return RedirectToAction("ReservationList");

        }



    }
}