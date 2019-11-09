using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_03_LabII_.Archivos;
using TP_03_LabII_.ClasesAbstractas;
using TP_03_LabII_.ClasesInstanciables;
using TP_03_LabII_.Excepciones;

namespace TP_03_LabII_.UnitTest
{
    [TestClass]
    public class UnitTestValorNumerico
    {
        [TestMethod]
        public void TestCantidadDeAlumnos()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno a1 = new Alumno(10, "Nombre", "Apellido", "12345678",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(20, "Nombre", "Apellido", "87654321",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                uni += a1;
                uni += a2;
                Assert.AreEqual(2, uni.Alumnos.Count);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }
    }
}
