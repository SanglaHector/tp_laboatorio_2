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
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor profesor):this()
        {
            this.clase = clase;
            this.instructor = profesor;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase de " + clase.ToString() + " Por " + instructor.ToString());
            sb.AppendLine("Alumnos:");
            foreach  (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public static  bool Guardar(Jornada jornada)
        {
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto texto = new Texto();
            return texto.Guardar(path, jornada.ToString());
        }
        public string Leer()
        {
            string datos;
            Texto texto = new Texto();
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            texto.Leer(path,out datos);
            return datos;
        }
    }
}
