using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _db;

        public BookController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Library.ToList();
            return View(books);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                _db.Library.Add(b);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(b);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = _db.Library.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                _db.Library.Update(b);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(b);
        }
    }
}
