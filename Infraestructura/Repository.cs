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
    }
}