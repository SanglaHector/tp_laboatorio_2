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
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
            {
                retorno = operador;
            }
            return retorno;
        }
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
