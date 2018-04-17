using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Dominio
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}