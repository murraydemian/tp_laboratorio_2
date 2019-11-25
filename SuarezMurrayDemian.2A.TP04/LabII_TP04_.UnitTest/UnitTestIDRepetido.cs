using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabII_TP04_.Entidades;

namespace LabII_TP04_.UnitTest
{
    [TestClass]
    public class UnitTestIDRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingRepetidoException))]
        public void TestMethodIDRepetido()
        {
            Paquete p1 = new Paquete("adress", "111");
            Paquete p2 = new Paquete("direccion", "111");
            Correo c1 = new Correo();
            c1 += p1;
            c1 += p2;
            Assert.Fail();
        }
    }
}
