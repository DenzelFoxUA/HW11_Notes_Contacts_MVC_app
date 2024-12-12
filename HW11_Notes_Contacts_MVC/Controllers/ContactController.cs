using HW11_Notes_Contacts_MVC.Data;
using HW11_Notes_Contacts_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using System.Diagnostics;

namespace HW11_Notes_Contacts_MVC.Controllers
{
    public class ContactController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = _context.Contacts;
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {

            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(contact);
        }

        public IActionResult ShowContact(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {

            if (ModelState.IsValid)
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteContact(int? id)
        {

            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
