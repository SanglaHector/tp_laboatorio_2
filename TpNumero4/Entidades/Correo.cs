using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            bool repertido = false;
            foreach(Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    repertido = true;
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }
            if (! repertido)
            {
                c.paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }
            return c;
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string st;
            string stFinal = "";
            List<Paquete> listaPaquetes = ((Correo)elementos).paquetes;
            //foreach(Paquete item in Paquetes)
            foreach (Paquete item in listaPaquetes)
            {
                st = string.Format("{0} para {1} ({2})", item.TrakingId, item.DireccionEntrega, item.Estado.ToString());
                stFinal = string.Format("{0}\n", st);
            }
            return stFinal;
        }
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                {
                    item.Abort();
                }
            }
        }
    }
}
