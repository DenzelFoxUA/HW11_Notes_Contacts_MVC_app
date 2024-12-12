
using HW11_Notes_Contacts_MVC.Data;
using HW11_Notes_Contacts_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HW11_Notes_Contacts_MVC.Controllers
{

    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> notes = _context.Notes;
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {

            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(note);
        }

        public IActionResult ShowNote(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }
            
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {

            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        [HttpPost]
        public IActionResult DeleteNote(int id)
        {

            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
