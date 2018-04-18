using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Infraestructura
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}