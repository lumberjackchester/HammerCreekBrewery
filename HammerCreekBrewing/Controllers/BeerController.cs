using HammerCreekBrewing.DTOs;
using HammerCreekBrewing.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace HammerCreekBrewing.Controllers
{
    public class BeerController : ApiController
    {
        private HammerCreekBrewingContext db = new HammerCreekBrewingContext();
        private readonly Expression<Func<Beer, BeerDto>> AsBeerDto = x => new BeerDto { Name = x.Name, Style = x.Style.StyleName };

        // GET api/Beer
        public IQueryable<BeerDto> GetBeers()
        {
            return db.Beers.Include(b=>b.Style).Select(AsBeerDto);
        }

        // GET api/Beer/5
        [ResponseType(typeof(Beer))]
        public async Task<IHttpActionResult> GetBeer(int id)
        {
            var beer = await db.Beers.Include(s => s.Style).Where(b => b.BeerId == id).Select(AsBeerDto).FirstOrDefaultAsync();
            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        // PUT api/Beer/5
        public IHttpActionResult PutBeer(int id, Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beer.BeerId)
            {
                return BadRequest();
            }

            db.Entry(beer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Beer
        [ResponseType(typeof(Beer))]
        public IHttpActionResult PostBeer(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Beers.Add(beer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beer.BeerId }, beer);
        }

        // DELETE api/Beer/5
        [ResponseType(typeof(Beer))]
        public IHttpActionResult DeleteBeer(int id)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return NotFound();
            }

            db.Beers.Remove(beer);
            db.SaveChanges();

            return Ok(beer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeerExists(int id)
        {
            return db.Beers.Count(e => e.BeerId == id) > 0;
        }
    }
}