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
using PizzeriaBackend.Models;
using System.IO;

namespace PizzeriaBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class PizzasController : ApiController
    {
        private PizzaContext db = new PizzaContext();
        readonly ILogger _logger;
        public PizzasController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: api/Pizzas
        public IEnumerable<Ingredient> Get()
        {
            return _logger.Ingredients();
        }

        // GET: api/Pizzas/5
        [ResponseType(typeof(Pizza))]
        [Route("pizzas")]
        public IEnumerable<Pizza> Get(int id)
        {
            List<UploadRequestViewModel> models = new List<UploadRequestViewModel>();
            List<Guid> IdIngredients = new List<Guid>();
            Decimal TotalCost;
            var pizzas = _logger.Pizzas();
            foreach (var pizza in pizzas)
            {
                TotalCost = 0m;
                foreach (var ingredient in pizza.Ingredients)
                {
                    IdIngredients.Add(ingredient.Id);
                    TotalCost += ingredient.Cost;
                }
                //models.Add(new UploadRequestViewModel() { Name = pizza.Name, Ingredients = IdIngredients, File = new MemoryStream(pizza.File) });
            }
            return _logger.Pizzas();
        }

        // PUT: api/Pizzas/5
        [ResponseType(typeof(void))]
        public void Put([FromBody]CreatePizza createPizza)
        {

        }

        // POST: api/Pizzas
        public void Post([FromBody]UploadRequestViewModel model)
        {
            MemoryStream file = new MemoryStream();
            CopyStream(model.File.InputStream, file);
            var createPizza = new CreatePizza() { Name = model.Name, Ingredients = model.Ingredients, Image = file.ToArray() };
            _logger.Write(createPizza);
        }

        // DELETE: api/Pizzas/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        private bool PizzaExists(Guid id)
        {
            return db.Pizza.Count(e => e.Id == id) > 0;
        }
    }
}