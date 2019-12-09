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
        /// <summary>
        /// Constructor de universitario
        /// </summary>
        public Universitario()
        {
        }
        /// <summary>
        /// Contructor de universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Muestra los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo: " + legajo);
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Dos un universitarios son iguales cuando su DNi o legajo son iguales y ademas sus tipos son iguales
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            return (u1.GetType() == u2.GetType() && (u1.legajo == u2.legajo || u1.DNI == u2.DNI));
        }
        /// <summary>
        /// Dos universitarios son diferentes cuando su dni, su tipo y legajo son diferentes
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        /// <summary>
        /// Override de Equals que retorna si es universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
    }
}
