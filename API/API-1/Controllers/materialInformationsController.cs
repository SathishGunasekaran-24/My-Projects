using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_1.Models;

namespace API_1.Controllers
{
    public class materialInformationsController : ApiController
    {
        private CivilEntities db = new CivilEntities();

        // GET: api/materialInformations
        public IQueryable<materialInformation> GetmaterialInformations()
        {
            return db.materialInformations;
        }

        // GET: api/materialInformations/5
        [ResponseType(typeof(materialInformation))]
        public async Task<IHttpActionResult> GetmaterialInformation(int id)
        {
            materialInformation materialInformation = await db.materialInformations.FindAsync(id);
            if (materialInformation == null)
            {
                return NotFound();
            }

            return Ok(materialInformation);
        }

        // PUT: api/materialInformations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutmaterialInformation(int id, materialInformation materialInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialInformation.materialId)
            {
                return BadRequest();
            }

            db.Entry(materialInformation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!materialInformationExists(id))
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

        // POST: api/materialInformations
        [ResponseType(typeof(materialInformation))]
        public async Task<IHttpActionResult> PostmaterialInformation(materialInformation materialInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.materialInformations.Add(materialInformation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = materialInformation.materialId }, materialInformation);
        }

        // DELETE: api/materialInformations/5
        [ResponseType(typeof(materialInformation))]
        public async Task<IHttpActionResult> DeletematerialInformation(int id)
        {
            materialInformation materialInformation = await db.materialInformations.FindAsync(id);
            if (materialInformation == null)
            {
                return NotFound();
            }

            db.materialInformations.Remove(materialInformation);
            await db.SaveChangesAsync();

            return Ok(materialInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool materialInformationExists(int id)
        {
            return db.materialInformations.Count(e => e.materialId == id) > 0;
        }
    }
}