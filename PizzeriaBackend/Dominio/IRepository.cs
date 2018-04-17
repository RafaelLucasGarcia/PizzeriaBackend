using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Dominio
{
    public interface IRepository
    {
        void Write(Pizza pizza);
    }
}