using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infraestructura
{
    public class Repository : IRepository
    {
        readonly IRepositoryPizza _repositoryPizza;
        public Repository(IRepositoryPizza repositoryPizza)
        {
            _repositoryPizza = repositoryPizza;
        }

        public void Write(Pizza pizza)
        {
            var set = _repositoryPizza.IDbSet(typeof(Pizza));
            set.Add(pizza);
        }
        public Ingredient Find(Guid IdIngrediente)
        {
            var set = _repositoryPizza.IDbSet(typeof(Ingredient));
            var ingrediente = (Ingredient)set.Find(IdIngrediente);
            return ingrediente;
        }

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredientes = new List<Ingredient>();
            var set = _repositoryPizza.IDbSet(typeof(Ingredient));
            foreach (var ingredient in set)
            {
                ingredientes.Add((Ingredient)ingredient);
            }
            return ingredientes;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            var set = _repositoryPizza.IDbSet(typeof(Pizza));
            foreach (var pizza in set)
            {
                pizzas.Add((Pizza)pizza);
            }
            return pizzas;
        }
    }
}