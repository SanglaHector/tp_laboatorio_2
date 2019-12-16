using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// /Valida que el operador sea "+" , "-" ,"/" o "*"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
            {
                retorno = operador;
            }
            return retorno;
        }
        /// <summary>
        /// Realiza la operacion entre los numeros pasados por parametros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return numeroUno + numeroDos;
                case "-":
                    return numeroUno - numeroDos;
                case "*":
                    return numeroUno * numeroDos;
                case "/":
                    return numeroUno / numeroDos;
                default:
                    return 0;
            }
        }
        #endregion
    }
}
