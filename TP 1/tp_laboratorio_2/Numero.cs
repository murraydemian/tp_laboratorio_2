using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_laboratorio_2
{
    class Numero
    {
        private double numero;
        /// <summary>
        /// Constructor por defecto. Setea el valor del numero en 0.
        /// </summary>
        public Numero() : this(0) { }
        /// <summary>
        /// Constructor parametrizado. Recibe un valor de tipo double y 
        /// lo setea como valor para el objeto Numero.
        /// </summary>
        /// <param name="numero">Valor que se asignara al objeto Numero.</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor parametrizado. Recive un valor de tipo string y
        /// valida que sea un numero. En caso que sea un numero lo setea
        /// como valor para el objeto Numero. Caso contrario setea el
        /// valor del objeto Numero en 0.
        /// </summary>
        /// <param name="strNumero">String que se verificara y asignara al objeto Numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Setter privado. Pasa el valor a setear por el metodo privado 
        /// ValidarNumero y luego lo asigna al objeto Numero.
        /// </summary>
        private string SetNumero{         
            set
            {
                numero = Numero.ValidarNumero(value);
            }
        }
        /// <summary>
        /// Metodo estatico y privado. Verifica que un string pasado por parametro
        /// sea parseable. De ser parseable retorna el valor del string. Caso
        /// contrario retorna 0.
        /// </summary>
        /// <param name="strNumero">String a ser validada y asignada</param>
        /// <returns>Valor parseado o 0</returns>
        public static double ValidarNumero(string strNumero)
        {
            double retValue = 0;
            if (!strNumero.Equals(null))
            {
                double buffer;
                if (double.TryParse(strNumero,out buffer))
                {
                    retValue = buffer;
                }
            }
            return retValue;
        }
        /// <summary>
        /// Convierte un string que representa un numero binario a un string
        /// que representa un numero decimal. De no poder realizar la 
        /// conversion retorna "Valor Invalido"
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>string convertido o "Valor Invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            string retStr = "Valor Invalido";
            if (!binario.Equals(null))
            {
                int i, j, buffer = 0;
                j = binario.Length -1;
                char actualValue;
                for (i=0;i<binario.Length;i++)
                {
                    actualValue = binario[j];
                    j--;
                    if (actualValue=='0')
                    {
                        continue;
                    }
                    else if (actualValue=='1')
                    {
                        buffer += (int)Math.Pow(2, i);
                    }
                    else
                    {
                        break;
                    }
                }
                if (i==binario.Length)
                {
                    retStr = buffer.ToString();
                }
            }
            return retStr;
        }
        /// <summary>
        /// Convierte un string representando un numero decimal a un
        /// string representando un numero binario. No convierte numeros 
        /// negativos. De ser un numero no entero se redondea al valor 
        /// mas cercano (ej: 1.6 se redondea a 2), de tener igual cercania
        /// para redondeos hacia arriba como hacia abajo se redondea al
        /// valor par (ej: 15.5 se redondea a 16).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Si pudo retorna un string con la conversion, caso contrario
        ///  retorna "Valor Invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            string textValue = "Valor Invalido";
            double numValue;
            if (Double.TryParse(numero,out numValue))
            {
                textValue = DecimalBinario(numValue);
            }
            return textValue;
        }
        /// <summary>
        /// Convierte un double a un
        /// string representando un numero binario. No convierte numeros 
        /// negativos. De ser un numero no entero se redondea al valor 
        /// mas cercano (ej: 1.6 se redondea a 2), de tener igual cercania
        /// para redondeos hacia arriba como hacia abajo se redondea al
        /// valor par (ej: 15.5 se redondea a 16).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Si pudo retorna un string con la conversion, caso contrario
        ///  retorna "Valor Invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            string ret = "Valor Invalido";
            if (numero >= 0)
            {
                ret = Convert.ToString(Convert.ToInt32(numero), 2);
            }
            return ret;
        }
        /// <summary>
        /// Sobrecarga de operador para poder operar con Objetos tipo Numero.
        /// No acepta division por 0;
        /// </summary>
        /// <param name="n1">objeto Numero en posicion N / x</param>
        /// <param name="n2">objeto Numero en posicion x / N</param>
        /// <returns>de ser posible retorna el resultado, caso contrario retorna -1</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return -1;
            }
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador para poder operar con Objetos tipo Numero.
        /// </summary>
        /// <param name="n1">objeto Numero en posicion N * x</param>
        /// <param name="n2">objeto Numero en posicion x * N</param>
        /// <returns>resultado de la operacion *</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador para poder operar con Objetos tipo Numero.
        /// </summary>
        /// <param name="n1">objeto Numero en posicion N + x</param>
        /// <param name="n2">objeto Numero en posicion x + N</param>
        /// <returns>resultado de la operacion +</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador para poder operar con Objetos tipo Numero.
        /// </summary>
        /// <param name="n1">objeto Numero en posicion N - x</param>
        /// <param name="n2">objeto Numero en posicion x - N</param>
        /// <returns>resultado de la operacion -</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
    }
}
