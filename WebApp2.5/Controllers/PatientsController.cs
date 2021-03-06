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
    public class PatientsController : Controller
    {
        private readonly ApplicationContextViewModel _context;

        public PatientsController(ApplicationContextViewModel context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Disease,Phone,cardNumber")] PatientsViewModel pa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var pa = await _context.Patients.FindAsync(id);
            if (pa == null) return NotFound();
            return View(pa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Disease,Phone,cardNumber")] PatientsViewModel pa)
        {
            if (id != pa.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(pa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pa);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var pa = await _context.Patients.FindAsync(id);
            if (pa == null) return NotFound();
            return View(pa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var pa = await _context.Patients.FindAsync(id);
            if (pa == null) return NotFound();
            _context.Patients.Remove(pa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
