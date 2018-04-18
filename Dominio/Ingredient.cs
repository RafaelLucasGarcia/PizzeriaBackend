using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Cost { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
    }
}