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
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_service.GetProducts());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "CategoryId", "Name");
            ViewData["MakerId"] = new SelectList(_service.GetMakers(), "MakerId", "Name");
            ViewData["SupplierId"] = new SelectList(_service.GetSuppliers(), "SupplierId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,Name,Description,Price,CategoryId,MakerId,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _service.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "CategoryId", "Name", product.CategoryId);
            ViewData["MakerId"] = new SelectList(_service.GetMakers(), "MakerId", "Name", product.MakerId);
            ViewData["SupplierId"] = new SelectList(_service.GetSuppliers(), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "CategoryId", "Name", product.CategoryId);
            ViewData["MakerId"] = new SelectList(_service.GetMakers(), "MakerId", "Name", product.MakerId);
            ViewData["SupplierId"] = new SelectList(_service.GetSuppliers(), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductId,Name,Description,Price,CategoryId,MakerId,SupplierId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "CategoryId", "Name", product.CategoryId);
            ViewData["MakerId"] = new SelectList(_service.GetMakers(), "MakerId", "Name", product.MakerId);
            ViewData["SupplierId"] = new SelectList(_service.GetSuppliers(), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _service.RemoveProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
