using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dominio
{
    public interface IRepositoryPizza
    {
        DbSet IDbSet(Type type);
    }
}