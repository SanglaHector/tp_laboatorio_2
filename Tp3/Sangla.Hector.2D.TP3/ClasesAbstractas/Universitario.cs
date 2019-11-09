using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario: Persona
    {
        int legajo;
        public Universitario():base()
        {
            legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo: " + legajo);
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool retorno = false;
            if(u1.DNI == u2.DNI  || u1.legajo == u2.legajo)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
    }
}
