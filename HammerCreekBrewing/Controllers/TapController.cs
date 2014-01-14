using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HammerCreekBrewing.Models;

namespace HammerCreekBrewing.Controllers
{
    public class OnTapController : Controller
    {
        private HCBContext db = new HCBContext();

        // GET: /Tap/
        public async Task<ActionResult> Index()
        {
            var beers = db.Beers.Include(b => b.Style);
            return View(await beers.ToListAsync());
        }

        // GET: /Tap/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = await db.Beers.FindAsync(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // GET: /Tap/Create
        public ActionResult Create()
        {
            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName");
            return View();
        }

        // POST: /Tap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="BeerId,Name,StyleId,TapName,LocationId,BrewDate,KeggedDate,TappedDate,Abv,KegId,OnTap")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        // GET: /Tap/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = await db.Beers.FindAsync(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        // POST: /Tap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BeerId,Name,StyleId,TapName,LocationId,BrewDate,KeggedDate,TappedDate,Abv,KegId,OnTap")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        // GET: /Tap/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = await db.Beers.FindAsync(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: /Tap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Beer beer = await db.Beers.FindAsync(id);
            db.Beers.Remove(beer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
