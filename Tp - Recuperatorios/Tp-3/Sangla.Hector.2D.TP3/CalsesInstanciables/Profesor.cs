using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    sealed public class Profesor: Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;
        /// <summary>
        /// Constructor de Proferor
        /// </summary>
        public  Profesor() 
        {
        }
        /// <summary>
        /// Contructor de profedor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor de profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Muestra los datos del profesor y de sus clases bases
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());    
            return sb.ToString();
        }
        /// <summary>
        /// Retorna las clases que el profesor tiene clasesDelDia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia: ");
            foreach (EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Llama a la clase mostrar datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
        /// <summary>
        /// otorga dos clases aleatorias al profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }
        /// <summary>
        /// Un profesor es igual a una clase si ese proferor da una esa clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor p, EClases clase)
        {
            bool retorno = false;
            foreach  (EClases item in p.clasesDelDia)
            {   
                if(item == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// un profesor es distinta a una clase si no da esa clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor p,EClases clase)
        {
            return !(p == clase);
        }
    }
}
