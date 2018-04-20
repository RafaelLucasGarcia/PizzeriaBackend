using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infraestructura
{
    public class Logger : ILogger
    {
        readonly IRepository _repository;
        readonly IUnitOfWork _unitOfWork;
        public Logger(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void Write(CreatePizza createPizza)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var IdIngredient in createPizza.Ingredients)
            {
                ingredients.Add(_repository.Find(IdIngredient));
            }
            var pizza = new Pizza()
            {
                Id = Guid.NewGuid(),
                Name = createPizza.Name,
                Ingredients = ingredients,
                Image = createPizza.Image
            };
            _repository.Write(pizza);
            _unitOfWork.SaveChanges();
        }
        public List<Ingredient> Ingredients()
        {
            return _repository.GetIngredients();
        }

        public List<Pizza> Pizzas()
        {
            return _repository.GetPizzas();
        }
    }
}