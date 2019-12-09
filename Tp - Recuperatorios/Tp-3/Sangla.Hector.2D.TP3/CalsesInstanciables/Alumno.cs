    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    sealed public class Alumno: Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// Constructor de alumno
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Constructor de alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Muesta los datos del alumno y de las clases bases
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Muestra la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Toma clases de: " + this.claseQueToma);
            return sb.ToString();
        }
        /// <summary>
        /// llama a la clase MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un alumno es igual a una Clase cuando la clase que toma el alumno es igual a la clase con la que se compara y cuando el estado
        /// de la cuenta del alumno no es deudor
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="e1"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a1, EClases e1)
        {
            bool retorno = false;
            if(a1.claseQueToma == e1 && a1.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Un alumno es diferente a una clase cuando este alumno no toma esa clase o su estado de cuenta es deudor
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="e1"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a1, EClases e1)
        {
            bool retorno = false;
            if (a1.claseQueToma != e1 )
            {
                retorno = true;
            }
            return retorno;
        }

    }
}
