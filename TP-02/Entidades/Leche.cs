using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(Producto.EMarca marca, string patente, ConsoleColor color, Leche.ETipo tipo)
            : base(patente, marca, color)
        {
            this.tipo = tipo;
        }

        public Leche(Producto.EMarca marca, string patente, ConsoleColor color)
            :this(marca, patente, color, Leche.ETipo.Entera)
        {

        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.Append("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.Append(" TIPO : " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("\r\n---------------------");

            return sb.ToString();
        }

        public enum ETipo
        {
            Entera,
            Descremada
        }
    }
}
