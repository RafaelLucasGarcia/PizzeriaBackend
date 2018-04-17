using PizzeriaBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Infrestructura
{
    public class PizzaContext : DbContext, IUnitOfWork, IRepositoryPizza
    {
        public PizzaContext() : base("PizzasEntities")
        {

        }

        public IDbSet<Pizza> Pizza { get; set; }
        public IDbSet<Ingredient> Ingredient { get; set; }

        public DbSet IDbSet(Type type)
        {
            return this.Set(type);
        }
    }
}