using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Dominio;
using Infraestructura;
using System.Web.Http.Cors;


namespace PizzeriaBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class PizzasController : ApiController
    {
        private PizzaContext db = new PizzaContext();

        // GET: api/Pizzas
        public IQueryable<Pizza> GetPizzas()
        {
            return db.Pizza;
        }

        // GET: api/Pizzas/5
        [ResponseType(typeof(Pizza))]
        public IHttpActionResult GetPizza(Guid id)
        {
            Pizza pizza = db.Pizza.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        // PUT: api/Pizzas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPizza(Guid id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pizza.Id)
            {
                return BadRequest();
            }

            db.Entry(pizza).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
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

        // POST: api/Pizzas
        [ResponseType(typeof(Pizza))]
        public IHttpActionResult PostPizza(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pizza.Add(pizza);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PizzaExists(pizza.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pizza.Id }, pizza);
        }

        // DELETE: api/Pizzas/5
        [ResponseType(typeof(Pizza))]
        public IHttpActionResult DeletePizza(Guid id)
        {
            Pizza pizza = db.Pizza.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Pizza.Remove(pizza);
            db.SaveChanges();

            return Ok(pizza);
        }

        /*public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PizzaExists(Guid id)
        {
            return db.Pizza.Count(e => e.Id == id) > 0;
        }
    }
}