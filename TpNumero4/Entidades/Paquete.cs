using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        private string direccionEntrega;
        private EEstado estado;
        private string trakingId;
        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
        public string TrakingId
        {
            get
            {
                return trakingId;
            }
            set
            {
                trakingId = value;
            }
        }
        #endregion
        public Paquete(string traking, string direccion)
        {
            this.TrakingId = traking;
            this.DireccionEntrega = direccion;
            this.Estado = EEstado.Ingresado;
        }
        public string MostrarDatos(IMostrar<Paquete> elementos)
        {
            Paquete p = (Paquete)elementos;
            string st = string.Format("{0} para {1}", p.TrakingId, p.DireccionEntrega);
            return st;
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        public void MockCicloDeVida()
        {
            do
            {
                InformarEstado(this, null);
                System.Threading.Thread.Sleep(4000);
                estado++;
            } while (estado <= EEstado.Entregado);
            //for (int i = 0; i < 3; i++)
            //{
            //    Estado = (EEstado)i;
            //    InformarEstado(this, new EventArgs());
            //    System.Threading.Thread.Sleep(4000);

            //}
            PaqueteDAO.Insertar(this);
        }
        #region Operadores
        public static bool operator ==(Paquete p1 , Paquete p2)
        {
            if(p1.TrakingId == p2.TrakingId)
            {
                return true;
            }
            return false;
        }
        public static bool operator != (Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
