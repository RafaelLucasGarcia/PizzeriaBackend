using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Infraestructura;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Pizza Get(int id)
        {
            var pizza = new Pizza() { Id = Guid.NewGuid(), Name = "Margarita" };
            pizza.Comments.Add(new Comments() { Id = Guid.NewGuid(), Name = "Otro.", UserName = "Pedro" });
            pizza.Ingredients.Add(new Ingredient() { Id = Guid.NewGuid(), Name = "Queso", Cost = 2.5m });
            pizza.Ingredients.Add(new Ingredient() { Id = Guid.NewGuid(), Name = "Tomate", Cost = 1.5m });
            _logger.Write(pizza);

            return pizza;
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
