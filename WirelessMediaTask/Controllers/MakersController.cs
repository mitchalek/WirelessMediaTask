using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WirelessMediaTask.Models;
using WirelessMediaTask.Services;

namespace WirelessMediaTask.Controllers
{
    public class MakersController : Controller
    {
        private readonly IProductsService _service;

        public MakersController(IProductsService service)
        {
            _service = service;
        }

        // GET: Makers
        public IActionResult Index()
        {
            return View(_service.GetMakers());
        }

        // GET: Makers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = _service.GetMaker(id.Value);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // GET: Makers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Makers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MakerId,Name")] Maker maker)
        {
            if (ModelState.IsValid)
            {
                _service.AddMaker(maker);
                return RedirectToAction(nameof(Index));
            }
            return View(maker);
        }

        // GET: Makers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = _service.GetMaker(id.Value);
            if (maker == null)
            {
                return NotFound();
            }
            return View(maker);
        }

        // POST: Makers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MakerId,Name")] Maker maker)
        {
            if (id != maker.MakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.AddMaker(maker);
                return RedirectToAction(nameof(Index));
            }
            return View(maker);
        }

        // GET: Makers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = _service.GetMaker(id.Value);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // POST: Makers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.RemoveMaker(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
