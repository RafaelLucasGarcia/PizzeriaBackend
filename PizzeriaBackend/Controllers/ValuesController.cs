using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Infraestructura;
using PizzeriaBackend.Models;

namespace PizzeriaBackend.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        readonly ILogger _logger;

        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/values
        public IEnumerable<Ingredient> Get()
        {
            return _logger.Ingredients();
        }

        // GET api/values/5
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

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing) {
            _logger.Dispose();
            base.Dispose(disposing);

        }
    }
}
