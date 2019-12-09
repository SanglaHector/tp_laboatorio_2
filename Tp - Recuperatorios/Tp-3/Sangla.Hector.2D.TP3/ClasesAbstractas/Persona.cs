using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private string nombre;
        private ENacionalidad nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #region Propiedades
        /// <summary>
        ///  Propiedad de nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad de dni
        /// </summary>
        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                if(ValidarDni(this.nacionalidad, value) == 1)
                {
                    dni = value;
                }
            }
        }
        /// <summary>
        /// Propiedad de dni
        /// </summary>
        public string StringToDNI
        {
            set
            {
                if (ValidarDni(this.nacionalidad, value) == 1)
                {
                    int.TryParse(value, out dni);
                }
            }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor de Persona
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Contructor de persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido,nacionalidad)
        {
            StringToDNI = dni;
        }
        #endregion
        /// <summary>
        /// Muestra los datos de persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre completo: " + Apellido + ", " + Nombre);
            sb.AppendLine("Nacionalidad: " + Nacionalidad);
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el dni este en los parametros segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni;
            if(dato > 0 && dato < 100000000)
            {
                if(nacionalidad == ENacionalidad.Argentino && (dato > 0 && dato < 90000000))
                {
                    dni = 1;
                }else if(nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato < 100000000))
                {
                    dni = 1;
                }
                else 
                {
                    throw new NacionalidadInvalidaException();
                }
                return dni;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// Valida que el DNI este entre los parametros segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoAuxiliar;
            int dni = 0;
            if(int.TryParse(dato, out datoAuxiliar) && (datoAuxiliar > 0 && datoAuxiliar < 100000000) && dato.Length < 9)
            {
                if (nacionalidad == ENacionalidad.Argentino && (datoAuxiliar > 0 && datoAuxiliar < 90000000))
                {
                    dni = 1;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && (datoAuxiliar >= 90000000 && datoAuxiliar < 100000000))
                {
                    dni = 1;
                }else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
            //return datoAuxiliar;
            return dni;
        }
        /// <summary>
        /// Valida el nombre y el apelldo
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno;
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$") && (dato.Length < 0))
            {
                retorno = dato;
            }
            else
            {
                retorno = "";
            }
            return retorno;
        }
    }
}
