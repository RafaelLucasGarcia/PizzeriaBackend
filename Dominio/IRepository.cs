using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public interface IRepository
    {
        void Write(Pizza pizza);
        Ingredient Find(Guid IdIngrediente);
        List<Ingredient> GetIngredients();
        List<Pizza> GetPizzas();
    }
}