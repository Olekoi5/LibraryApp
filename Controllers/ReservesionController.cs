using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class ReservesionController : Controller
    {
        private readonly LibraryContext _db;

        public ReservesionController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var reservesions = _db.Reservesions.Where(r => r.bookId.id == id).ToList();
            return View("BookReservations", reservesions);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var r = new Reservesion
            {
                DateReservesion = DateTime.Today,
                bookId = _db.Library.Find(id),
                userLogin = User.Identity.Name
            };
            _db.Reservesions.Add(r);
            _db.SaveChanges();
            return View(r);
        }
    }
}
