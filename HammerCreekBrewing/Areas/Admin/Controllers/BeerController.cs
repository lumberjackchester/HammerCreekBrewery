using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HammerCreekBrewing.Data;
using HammerCreekBrewing.Data.Models;

namespace HammerCreekBrewing.Areas.Admin.Controllers
{
    public class BeerController : Controller
    {
        private HCBContext db = new HCBContext();

        // GET: /Admin/Beer/
        public async Task<ActionResult> Index()
        {
            var beers = db.Beers.Include(b => b.Style);
            return View(await beers.ToListAsync());
        }

        // GET: /Admin/Beer/Details/5
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

        // GET: /Admin/Beer/Create
        public ActionResult Create()
        {
            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName");
            return View();
        }

        // POST: /Admin/Beer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="BeerId,Name,StyleId,TapName,LocationId,BrewDate,KeggedDate,TappedDate,Abv,KegId,OnTap")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                await db.CommitAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        // GET: /Admin/Beer/Edit/5
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

        // POST: /Admin/Beer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BeerId,Name,StyleId,TapName,LocationId,BrewDate,KeggedDate,TappedDate,Abv,KegId,OnTap")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beer).State = EntityState.Modified;
                await db.CommitAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StyleId = new SelectList(db.BeerStyles, "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        // GET: /Admin/Beer/Delete/5
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

        // POST: /Admin/Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Beer beer = await db.Beers.FindAsync(id);
            db.Beers.Remove(beer);
            await db.CommitAsync();
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
