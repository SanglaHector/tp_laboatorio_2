﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class ArchivosException:Exception
    {
        public ArchivosException():base("Error al procesar archivos")
        {
        }
    }
}
