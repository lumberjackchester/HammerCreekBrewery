﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HammerCreekBrewing.Services;
using HammerCreekBrewing.ViewModels;
using HammerCreekBrewing.Data.Models;
using System.Linq.Expressions;

namespace HammerCreekBrewing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly ILogging _logger;

        //private readonly Expression<Func<BeerStyle, BeerStyleViewModel>> AsStyleViewModel = x => new BeerStyleViewModel { Name = x.StyleName, Id = x.Style.StyleName };
        //private readonly Expression<Func<Location, LocationViewModel>> AsLocationViewModel = x => new LocationViewModel { Name = x.Name, Style = x.Style.StyleName };
        //private readonly Expression<Func<Beer, BeerViewModel>> AsBeerViewModel = x => new BeerViewModel { Name = x.Name, Style =  };

        //
        // GET: /Home/
        public HomeController(IBeerService beerService, ILogging logger)
        {
            _beerService = beerService;
            _logger = logger;
        }

        public ActionResult Index()
        { 
            return View(new ViewModels.HomeViewModel());
        }

        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
