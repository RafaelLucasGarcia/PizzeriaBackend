﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public interface ILogger : IDisposable
    {
        void Write(Pizza pizza);
    }
}