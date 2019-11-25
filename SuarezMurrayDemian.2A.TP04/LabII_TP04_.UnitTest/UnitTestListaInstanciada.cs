using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabII_TP04_.Entidades;

namespace LabII_TP04_.UnitTest
{
    [TestClass]
    public class UnitTestListaInstanciada
    {
        [TestMethod]
        public void TestMethodListaInstanciada()
        {
            Correo c1 = new Correo();
            if(c1.Paquetes.Equals(null))
            {
                Assert.Fail();
            }
        }
    }
}
