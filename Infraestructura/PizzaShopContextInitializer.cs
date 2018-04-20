using Infraestructura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class PizzaShopContextInitializer : CreateDatabaseIfNotExists<PizzaContext>
    {
        protected override void Seed(PizzaContext context)
        {
            List<Ingredient> ingredients = new List<Ingredient>
            {
                new Ingredient {Id=Guid.NewGuid(), Name="Peperoni", Cost=0.3M},
                new Ingredient {Id=Guid.NewGuid(), Name="Mozzarella", Cost=0.5M},
                new Ingredient {Id=Guid.NewGuid(), Name="Champiñones", Cost=0.2M},
                new Ingredient {Id=Guid.NewGuid(), Name="Bacon", Cost=0.7M},
                new Ingredient {Id=Guid.NewGuid(), Name="Piña", Cost=-0.3M},
                new Ingredient {Id=Guid.NewGuid(), Name="Pollo", Cost=0.6M},
                new Ingredient {Id=Guid.NewGuid(), Name="Tomate", Cost=0.25M},
                new Ingredient {Id=Guid.NewGuid(), Name="Nata", Cost=0.4M},
                new Ingredient {Id=Guid.NewGuid(), Name="Ternera", Cost=0.8M},
                new Ingredient {Id=Guid.NewGuid(), Name="Salsa Barbacoa", Cost=0.3M},
                new Ingredient {Id=Guid.NewGuid(), Name="Parmesano", Cost=0.2M},
                new Ingredient {Id=Guid.NewGuid(), Name="Blue Cheese", Cost=0.5M},
                new Ingredient {Id=Guid.NewGuid(), Name="Gorgonzzolla", Cost=0.4M},
                new Ingredient {Id=Guid.NewGuid(), Name="Chocolate", Cost=0.3M}
            };

            // add data into context and save to db
            foreach (Ingredient i in ingredients)
            {
                context.Ingredient.Add(i);
            }
            context.SaveChanges();

        }
    }
}
