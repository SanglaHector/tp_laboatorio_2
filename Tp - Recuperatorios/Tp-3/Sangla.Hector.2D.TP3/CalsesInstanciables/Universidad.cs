using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;
        /// <summary>
        /// Enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        /// <summary>
        /// propiedad de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }
        /// <summary>
        /// propiedad de profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }


        /// <summary>
        /// propiedad de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }
        /// <summary>
        /// propiedad de jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                Jornadas[i] = value;
            }
        }
        /// <summary>
        /// Constructor de universidad
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }
        /// <summary>
        /// Lee un archivo xml y genera un objeto  univeridad con esos datos
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad g = new Universidad();
            string path = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            xml.Leer(path, out g);
            return g;
        }
        /// <summary>
        /// guarda en un archivo xml los datos de una universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool ret = false;
            string path = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            ret = xml.Guardar(path, uni);
            return ret;
        }
        /// <summary>
        /// espone los datos de la univerdidad
		/// <summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MostrarDatos(this));
            return sb.ToString();
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS: ");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }
        #region Operadores
        /// <summary>
        /// una universidad es diferente a un alumno, si el alumno no pertenece a esa universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// una universidad es diferente a un profesor, cuando este no pertenece a la lista de profesores de esa universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// una universidad es difereten a una clase cuando no tiene profesores que den esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// una universidad es igual a un alumno si el alumno pertenece a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// una universidad es diferente a un profesor, si este no pertenece a la lista de profesores de la univesidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// una universidad es diferente a una clase cuando la universidad tiene un profesor que da esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// si el alumno no pertenece a la universidad, se agrega
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
                return g;
            }
            throw new AlumnoRepetidoException();
        }
        /// <summary>
        /// si el proferos no pertenece a la universidad, se agrega
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g==clase);
            g.jornadas.Add(jornada);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            return g;
        }
        #endregion
    }
}
