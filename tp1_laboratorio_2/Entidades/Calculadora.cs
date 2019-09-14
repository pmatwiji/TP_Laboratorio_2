using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido sea +,-,/ o *.Caso Contrario retornara +.
        /// </summary>
        /// <param name="operador">String a validar si es un operador</param>
        /// <returns>Operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            string OperadorRetorno = "";

            switch (operador)
            {
                case "-":
                    OperadorRetorno = "-";
                    break;
                case "*":
                    OperadorRetorno = "*";
                    break;
                case "/":
                    OperadorRetorno = "/";
                    break;
                default:
                    OperadorRetorno = "+";
                    break;
            }

            return OperadorRetorno;
        }

        /// <summary>
        /// Realiza la operacion pasada por parametro entre los dos numeros pasados por parametro
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador que se utiliza</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            operador = ValidarOperador(operador);
            double resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
