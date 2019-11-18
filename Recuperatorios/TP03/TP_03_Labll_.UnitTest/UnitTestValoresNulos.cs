using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_03_LabII_.Archivos;
using TP_03_LabII_.ClasesAbstractas;
using TP_03_LabII_.ClasesInstanciables;
using TP_03_LabII_.Excepciones;

namespace TP_03_Labll_.UnitTest
{
    [TestClass]
    public class UnitTestValoresNulos
    {
        [TestMethod]
        public void TestUniversidadNull()
        {
            try
            {
                Universidad uni = new Universidad();
                Assert.AreNotEqual(null, uni.Alumnos);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
