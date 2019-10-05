using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    /// 
    //public sealed class Producto
    public abstract class Producto
    {
        //enum EMarca
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        // agrego Contructor
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        // abstract short CantidadCalorias { get; set; }
        public abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        //sealed string Mostrar()
        public virtual string Mostrar()
        {
            //return this;
            return (string)this;
        }

        //  private static explicit operator string(Producto p)
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());

            //sb.AppendLine("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            //sb.AppendLine("MARCA          : {0}\r\n", p.marca.ToString());
            //sb.AppendLine("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            // return sb;
            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            // validé que no vengan nulos los parametros
            bool retorno = false;
            if (!v1.Equals(null) || !v2.Equals(null))
            {
                return (v1.codigoDeBarras == v2.codigoDeBarras);
            }
            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            // return (v1.codigoDeBarras == v2.codigoDeBarras);
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
