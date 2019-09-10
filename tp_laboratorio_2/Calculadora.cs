using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_laboratorio_2
{
    class Calculadora
    {
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
