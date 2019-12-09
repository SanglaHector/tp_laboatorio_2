using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ClasesInstanciables;
using static ClasesInstanciables.Universidad;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        /// <summary>
        /// Propiedad alumnos
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
        /// Propiedad clase
        /// </summary>
        public EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }
        /// <summary>
        /// Propiedad instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }
        /// <summary>
        /// Constructor de Jornada
        /// </summary>
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="profesor"></param>
        public Jornada(EClases clase, Profesor profesor):this()
        {
            this.clase = clase;
            this.instructor = profesor;
        }
        /// <summary>
        /// Devuelde los datos de la jornada    
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase de " + clase.ToString() + " Por " + instructor.ToString());
            sb.AppendLine("Alumnos:");
            foreach  (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static  bool Guardar(Jornada jornada)
        {
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto texto = new Texto();
            return texto.Guardar(path, jornada.ToString());
        }
        /// <summary>
        /// lee los datos de un archivo de texto y los devuelve en un string
        /// </summary>
        /// <returns></returns>
        public static  string Leer()
        {
            string datos;
            Texto texto = new Texto();
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            texto.Leer(path,out datos);
            return datos;
        }
        /// <summary>
        /// si el alumno no esta en la jornada, se agrega
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j , Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
                return j;
            }
            return j;
        }
        /// <summary>
        ///un alumno es igual a una jornada cuando este pertenece a la jornada 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.Alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// un alumno es diferente a una jornada, cuando este no pertenece a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j , Alumno a)
        {
            return !(j == a);
        }
    }
}
