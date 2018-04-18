using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Dominio;
using Infraestructura;

namespace PizzeriaBackend.Controllers
{
    public class PizzasController : ApiController
    {
        private PizzaContext db = new PizzaContext();

        // GET: api/Pizzas
        public IQueryable<Pizza> GetPizzas()
        {
            return db.Pizzas;
        }

        // GET: api/Pizzas/5
        [ResponseType(typeof(Pizza))]
        public IHttpActionResult GetPizza(Guid id)
        {
            Pizza pizza = db.Pizzas.Find(id);
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

            db.Pizzas.Add(pizza);

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
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return Ok(pizza);
        }

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
            return db.Pizzas.Count(e => e.Id == id) > 0;
        }
    }
}