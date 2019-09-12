using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_laboratorio_2
{
    class Calculadora
    {
        /// <summary>
        /// Verifica que el operador seleccionado sea un operador valido.
        /// </summary>
        /// <param name="operador">operador seleccionado</param>
        /// <returns>de ser valido; el operador, caso contrario; +</returns>
        private static string ValidarOperador(string operador)
        {
            string retOp = "+";
            if (!operador.Equals(null))
            {
                if (operador=="+" || operador=="-" || operador =="/" || operador=="*")
                {
                    retOp = operador;
                }
                
            }
            return retOp;
        }
        /// <summary>
        /// Realiza una operacion determinada sobre dos objetos tipo Numero
        /// </summary>
        /// <param name="num1">objeto Numero en posicion N op x</param>
        /// <param name="num2">objeto Numero en posicion x op N</param>
        /// <param name="operador">operacion</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double result;
            operador = Calculadora.ValidarOperador(operador);
            switch(operador)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}
