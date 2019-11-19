using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabII_TP04_.Entidades
{
    public interface IMostrar<T>
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
