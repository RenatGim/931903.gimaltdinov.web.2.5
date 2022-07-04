using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp2._5.Models;

namespace WebApp2._5.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationContextViewModel _context;

        public DoctorsController(ApplicationContextViewModel context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Speciallity")] DoctorViewModel doc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Speciallity")] DoctorViewModel doc)
        {
            if (id != doc.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            return View(doc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
