using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructor

        public Numero() : this(0)
        {

        }

        public Numero(double numero) : this(numero.ToString())
        {

        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        private double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double numero))
            {
                numero = 0;
            }

            return numero;
        }

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        #region Operadores

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            if(n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }

            return resultado; 
        }

        #endregion


        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>Numero pasado a decimal</returns>
        public string BinarioDecimal(string binario)
        {
            int aux = 0;
            int numero = 0;
            int potencia = 0;
            string binarioStr = "";

            if (int.TryParse(binario, out aux) == true)
            {
                if (aux >= 0)
                {
                    for(int i = 0; i < binario.Length; i++)
                    {
                        binarioStr = binario[i] + binarioStr;
                    }

                    for (int i = 0; i < binarioStr.Length; i++)
                    {
                        potencia = (int)Math.Pow(2, i);

                        if (binarioStr[i] == '1')
                        {
                            numero = numero + potencia;
                        }
                    }
                }
                else
                {
                    binarioStr = "Valor invalido";
                }
            }
            else
            {
                binarioStr = "Valor invalido";
            }

            binarioStr = numero.ToString();
            return binarioStr;
        }

        /// <summary>
        /// Convierte un numero de decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero pasado a binario</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int resto;

            if (Int32.TryParse(Convert.ToString(numero), out int entero))
            {
                while (entero > 0)
                {
                    resto = (entero % 2);

                    if (resto == 0)
                    {
                        binario = 0 + binario;
                    }
                    else
                    {
                        binario = 1 + binario;
                    }

                    entero = entero / 2;
                }
            }else
            {
                binario = "Valor invalido";
            }
            return binario;
        }

        public string DecimalBinario(string numero)
        {
            string binario = "";
            if(double.TryParse(numero, out double numDecimal))
            {
                binario = DecimalBinario(numDecimal);
            }
            else
            {
                binario = "Valor Invalido";
            }

            return binario;
        }
    }
}

