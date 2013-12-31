using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HammerCreekBrewing.Models;

namespace HammerCreekBrewing.Controllers
{
    public class BeerController : ApiController
    {
        private HammerCreekBrewingContext db = new HammerCreekBrewingContext();

        // GET api/Default1
        public IEnumerable<Beer> GetBeers()
        {
            var beers = db.Beers.Include(b => b.Style);
            return beers.AsEnumerable();
        }

        // GET api/Default1/5
        public Beer GetBeer(int id)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return beer;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutBeer(int id, Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != beer.BeerId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(beer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Default1
        public HttpResponseMessage PostBeer(Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, beer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = beer.BeerId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteBeer(int id)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Beers.Remove(beer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, beer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}