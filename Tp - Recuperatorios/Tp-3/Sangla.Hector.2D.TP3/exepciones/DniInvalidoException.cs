﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(): base("DNI invalido.")
        {

        }
        public DniInvalidoException(Exception e):base(e.Message)
        {
        }
        public DniInvalidoException(string mensaje):base(mensaje)
        {

        }
        public DniInvalidoException(string mensaje, Exception e):base(mensaje,e)
        {

        }

    }
}
