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

        public  Profesor() :base()
        {

        }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
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
        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(5));
            System.Threading.Thread.Sleep(1000);
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
        }
        public static bool operator ==(Profesor p, EClases clase)
        {
            bool retorno = false;
            foreach  (EClases item in p.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Profesor p,EClases clase)
        {
            return !(p == clase);
        }
    }
}
