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

        public Numero() : this(0) { }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        private string SetNumero{         
            set
            {
                numero = Numero.ValidarNumero(value);
            }
        }
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
        public string BinarioDecimal(string binario)
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
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(Double.Parse(numero));
        }
        public string DecimalBinario(double numero)
        {
            string ret = "Valor Invalido";
            if (numero > 0)
            {
                ret = Convert.ToString(Convert.ToInt32(numero), 2);
            }
            return ret;
        }
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return -1;
            }
            return n1.numero / n2.numero;
        }
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
    }
}
