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
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;

namespace HammerCreekBrewing.Controllers
{
    public class OnTapController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogging _logger;
        private readonly IBeerService _beerService; 
        private readonly IBeerStylesService _styleService; 
        public OnTapController(IUnitOfWork unit, IBeerService beerServ, IBeerStylesService _styleServ, ILogging logger)
        {
            _uow = unit;
            _beerService = beerServ;
            _styleService = _styleServ;
            _logger = logger;
        }

        // GET: /Tap/
        public async Task<ActionResult> Index()
        {
            var beers = await _beerService.GetAllBeersAsync<BeerMenuViewModel>();
            return View(beers);
        }
        
        // GET: /Tap/Create
        public ActionResult Create()
        {
            ViewBag.StyleId = new SelectList(_styleService.GetBeerStyles(), "BeerStyleId", "StyleName");
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
                _uow.Beers.Add(beer);
                await _uow.CommitAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StyleId = new SelectList( await _styleService.GetBeerStylesAsync(), "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        //// GET: /Tap/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Beer beer = await _beerService.GetBeerAsync(id);
        //    if (beer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.StyleId = new SelectList(await _styleService.GetBeerStylesAsync(), "BeerStyleId", "StyleName", beer.StyleId);
        //    return View(beer);
        //}

        // POST: /Tap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BeerId,Name,StyleId,TapName,LocationId,BrewDate,KeggedDate,TappedDate,Abv,KegId,OnTap")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _uow.Beers.Update(beer);
                await _uow.CommitAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StyleId = new SelectList(await _styleService.GetBeerStylesAsync(), "BeerStyleId", "StyleName", beer.StyleId);
            return View(beer);
        }

        //// GET: /Tap/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Beer beer = await _beerService.GetBeerAsync(id);
        //    if (beer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(beer);
        //}

        //// POST: /Tap/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Beer beer = await _beerService.GetBeerAsync(id);
        //    _uow.Beers.Delete(beer);
        //    await _uow.CommitAsync();
        //    return RedirectToAction("Index");
        //}

        
    }
}
