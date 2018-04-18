using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infraestructura
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}