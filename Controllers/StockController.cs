using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Stock> obj = _db.Stocks;
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stock stock)
        {
            if (stock != null) 
            {
                DateTime now = DateTime.Now;
                stock.Date = now;
                _db.Add(stock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null) {
                return NotFound();
                }
            var obj = _db.Stocks.Find(id);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var obj = _db.Stocks.Find(id);
            _db.Stocks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Update
        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db.Stocks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _db.Stocks.Update(stock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return View(stock);
            }
        }
    }
}
